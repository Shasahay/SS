import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgxFileDropEntry, FileSystemFileEntry } from "ngx-file-drop";
import {ToastrService} from 'ngx-toastr'

@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.scss']
})
export class FileUploadComponent implements OnInit {
  @Input() maxFiles: number;
  @Input() fileType : string;
  @Input() uploadType : string;
  @Output() fileUploadEvent = new EventEmitter<File[]>();
  files : File[] = [];
  constructor(private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  dropped(files: NgxFileDropEntry[]): void{
    debugger
    if(!files){
      return;
    }
    files.forEach( (uploadedFile, index) => {
      const fileEntry = uploadedFile.fileEntry as FileSystemFileEntry;
      fileEntry.file((file: File) => {
        if(this.files.filter( x=> x.name === file.name).length > 0){
          this.toastr.success('File already selected')
        }
        else{
          if(this.files.length === this.maxFiles){
            this.toastr.success('Max'+this.maxFiles+'files are allowed')
            return;
          }
          let size = file.size;
          if(!(size / 1024 / 1024 <= 500)){
            this.toastr.success("File size is greater than 500mb")
            return;
          }
          var file_name = file.name.split('.');
          var file_extension = file_name[file_name.length -1];
          if(!this.fileType.split(',').find( x=> x.toLowerCase() === file_extension)){
            this.toastr.info('File format is incorrect')
          }
          this.files.push(file);
          this.fileUploadEvent.emit(this.files);
        }
      })
    })
  }

  removeSelectedFile(fileName, index){
    debugger
    //this.files.filter((x) => x.name !==fileName); 
    //this.files = this.files.splice(index)
    // index is not coming with correctly or might be it will index + 1 so following approach
    this.files = this.files.splice(index+1, 1) // if this does not work uncommen the below line
    // this.files.forEach((vlu, idx) => {
    //   if(vlu.name == fileName) this.files.splice(idx,1);
    // })
    this.fileUploadEvent.emit(this.files);
  }
}
