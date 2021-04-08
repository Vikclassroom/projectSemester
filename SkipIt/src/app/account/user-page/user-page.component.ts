import { Component, OnInit } from '@angular/core';
import {environment} from '../../../environments/environment';
import { AuthService } from '../service/auth.service';

@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.scss']
})
export class UserPageComponent implements OnInit {
  UrlPicture: string;
  public baseUrl = environment.apiUrl;
  public path = 'assets/img/';
  public root = this.baseUrl + this.path + localStorage.getItem('urlPicture');
  public email: string;
  constructor(private service: AuthService) { }

  ngOnInit(): void {
      this.email = localStorage.getItem('email');
  }

  // tslint:disable-next-line:typedef
  changePicture(event) {
    const files = event.srcElement.files;
    if (!files) {
      return ;
    }
    // tslint:disable-next-line:radix
    const id = localStorage.getItem('id');
    const formData: FormData = new FormData();
    formData.append('idCurrentAccount', id);
    this.service.updatePicture(formData).subscribe(() => {}, error => {
      console.log(error);
    });
  }
}
