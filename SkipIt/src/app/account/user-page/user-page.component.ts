import { Component, OnInit } from '@angular/core';
import {environment} from '../../../environments/environment';
import { AuthService } from '../service/auth.service';
import {FormControl, FormGroup, Validators} from '@angular/forms';

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
  public currentId = localStorage.getItem('id');
  constructor(private service: AuthService) { }
  form = new FormGroup({
    idCurrentUser: new FormControl('', [Validators.required]),
    file: new FormControl('', [Validators.required]),
    fileSource: new FormControl('', [Validators.required])
  });

  ngOnInit(): void {
      this.email = localStorage.getItem('email');
  }

  // tslint:disable-next-line:typedef
  changePicture(event) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.form.patchValue({
        fileSource: file
      });

      const formData = new FormData();
      formData.append('file', this.form.get('fileSource').value);

      // tslint:disable-next-line:radix
      this.service.updatePicture(formData , parseInt(this.currentId)).subscribe();
    }
  }
}
