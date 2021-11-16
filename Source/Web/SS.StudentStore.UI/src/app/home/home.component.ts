import { Component, OnInit } from '@angular/core';
import { Application_Constants } from '../shared/constants/application-constant';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  paperbookTileTitle: string =   Application_Constants.paperbookTileTitle;
  paperbookTileSubTitle: string = Application_Constants.paperbookTileSubTitle;
  paperbookTileContent: string =  Application_Constants.paperbookTileContent;
  paperbookTileImage: string = Application_Constants.paperbookTileImage;
  tileButtonTitle: string = Application_Constants.tileButtonTitle
  tileButtonLink: string = Application_Constants.tileButtonLink;

  ebookTileTitle: string =   Application_Constants.ebookTileTitle;
  ebookTileSubTitle: string = Application_Constants.ebookTileSubTitle;
  ebookTileContent: string =  Application_Constants.ebookTileContent;
  ebookTileImage: string = Application_Constants.ebookTileImage;
  

  subscribeItemTileTitle: string =   Application_Constants.subscribeItemTileTitle;
  subscribeItemTileSubTitle: string = Application_Constants.subscribeItemTileSubTitle;
  subscribeItemContent: string =  Application_Constants.subscribeItemContent;
  subscribeItemTileImage: string = Application_Constants.subscribeItemTileImage;

  uploadBookTileTitle: string =   Application_Constants.uploadBookTileTitle;
  uploadBookTileSubTitle: string = Application_Constants.uploadBookTileSubTitle;
  uploadBookContent: string =  Application_Constants.uploadBookContent;
  uploadBookTileImage: string = Application_Constants.uploadBookTileImage;

  uploaNoteTileTitle: string =   Application_Constants.uploaNoteTileTitle;
  uploadNoteTileSubTitle: string = Application_Constants.uploadNoteTileSubTitle;
  uploadNoteContent: string =  Application_Constants.uploadNoteContent;
  uploadNoteTileImage: string = Application_Constants.uploadNoteTileImage;
  
  constructor() { }

  ngOnInit(): void {
  }

}
