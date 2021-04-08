import { Component, OnInit } from '@angular/core';
import {environment} from '../../../environments/environment';

@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.scss']
})
export class UserPageComponent implements OnInit {
  UrlPicture: string;
  public baseUrl = environment.apiUrl;
  public path = 'assets/img/';

  constructor() { }

  ngOnInit(): void {
  }

  // tslint:disable-next-line:typedef
  public getImg(){
    return this.UrlPicture = localStorage.getItem('urlPicture');
  }
}
