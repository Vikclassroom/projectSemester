import {Component, OnInit, Output} from '@angular/core';
import {environment} from '../../../environments/environment';
import {AuthService} from '../service/auth.service';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {Router} from '@angular/router';
import {confirmPassword} from './confirmPassword';

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
  // tslint:disable-next-line:radix
  public currentId = parseInt(localStorage.getItem('id'));
  updateForm: FormGroup;

  constructor(private service: AuthService, private router: Router, private fb: FormBuilder) {
    this.updateForm = fb.group({
      email: ['', [Validators.required, Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$')]],
      password: ['', Validators.required],
      password_retype: ['', Validators.required]
    }, {
      validator: confirmPassword('password', 'password_retype')
    });
  }

  form = new FormGroup({
    idCurrentUser: new FormControl('', [Validators.required]),
    file: new FormControl('', [Validators.required]),
    fileSource: new FormControl('', [Validators.required])
  });

  ngOnInit(): void {
    this.email = localStorage.getItem('email');
  }


  // tslint:disable-next-line:typedef
  changePicture(files: FileList) {
    if (files.length > 0) {
      const file = files.item(0);

      const formData = new FormData();
      formData.append('file', file, file.name);

      // tslint:disable-next-line:radix
      this.service.updatePicture(formData, this.currentId).subscribe(() => {
        this.service.downloadPicture(this.currentId).subscribe((data) => {
          localStorage.setItem('urlPicture', data);
          window.location.reload();
        });
      });
    }
  }

  // tslint:disable-next-line:typedef
  updateProfile() {
    this.service.updateUser(this.updateForm.value).subscribe(() => {
      this.router.navigateByUrl('user');
    }, error => {
      console.log(error);
    });
  }
}
