import {Component,Input,Output,EventEmitter} from '@angular/core';

@Component({
  selector: 'app-multi-select-dropdown',
  templateUrl: './multi-select-dropdown.component.html',
  styleUrls: ['./multi-select-dropdown.component.scss']
})
export class MultiSelectDropdownComponent {
  @Input() list:any[]; 
  showDropDown : boolean = false;
    @Output() shareCheckedList = new EventEmitter();
    @Output() shareIndividualCheckedList = new EventEmitter();
    
    
    checkedList : any[];
    currentSelected : {};
    selectioncheckedList : any[];
  constructor() {
    this.checkedList = [];
    this.selectioncheckedList = [];
   }

       getSelectedValue(status:Boolean,value:any){
        if(status){
          this.checkedList.push(value);  
          this.selectioncheckedList.push(value.name);
        }else{
            var index = this.checkedList.indexOf(value);
            this.checkedList.splice(index,1);
            this.selectioncheckedList.splice(index,1);
        }
        
        this.currentSelected = {checked : status,name:value};

        //share checked list
        this.shareCheckedlist();
        
        //share individual selected item
        this.shareIndividualStatus();
    }
    shareCheckedlist(){
         this.shareCheckedList.emit(this.checkedList);
    }
    shareIndividualStatus(){
        this.shareIndividualCheckedList.emit(this.currentSelected);
    }



}
