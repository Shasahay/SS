import { Component, OnInit, Inject, ViewChild} from '@angular/core';
import { MAT_DIALOG_DATA} from '@angular/material/dialog';
import { PdfViewerComponent } from 'ng2-pdf-viewer';

@Component({
  selector: 'app-product-preview',
  templateUrl: './product-preview.component.html',
  styleUrls: ['./product-preview.component.scss']
})
export class ProductPreviewComponent implements OnInit {
   @ViewChild(PdfViewerComponent, {static: false})
   private pdfComponent: PdfViewerComponent;
  constructor( @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit(): void {
  }

  pageRendered() {
    //this.pdfComponent.pdfViewer.currentScaleValue = 'page-fit';
  }
  
}
