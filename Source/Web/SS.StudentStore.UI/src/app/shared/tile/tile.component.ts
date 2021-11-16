import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-tile',
  templateUrl: './tile.component.html',
  styleUrls: ['./tile.component.scss']
})
export class TileComponent implements OnInit {
  @Input() title;
  @Input() SubTitle: string
  @Input() content: string
  @Input() image: string
  @Input() buttonTitle: string
  @Input() buttonHlink: string
  constructor() { }

  ngOnInit(): void {
  }

}
