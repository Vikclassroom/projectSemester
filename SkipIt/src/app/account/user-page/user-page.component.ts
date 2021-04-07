import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.scss']
})
export class UserPageComponent implements OnInit {
  UrlPicture: string;
  constructor() { }

  ngOnInit(): void {
  }

  // tslint:disable-next-line:typedef
  public getImg(){
    this.UrlPicture = localStorage.getItem('urlPicture');
  }
}
