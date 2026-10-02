import { Component } from '@angular/core';

@Component({
  imports: [],
  selector: 'app-member-list',
  styleUrl: './member-list.css',
  templateUrl: './member-list.html',
})
export class MemberList {
  protected showText = true;
  public HideText () {
    this.showText = false;
  }
  public ShowText () {
    this.showText = true;
  }

  
}
