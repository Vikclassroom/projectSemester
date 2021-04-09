import {Component, OnInit} from '@angular/core';
import {AuthService} from '../service/auth.service';
import {FormGroup, FormControl, Validators, FormBuilder} from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import {confirmPassword} from './confirmPassword';


@Component({
  selector: 'app-sign',
  templateUrl: './sign.component.html',
  styleUrls: ['./sign.component.scss']
})

export class SignComponent implements OnInit {
  registerForm: FormGroup;
  loginForm: FormGroup;

  constructor(private service: AuthService, private router: Router, private activatedRoute: ActivatedRoute, private fb: FormBuilder) {
    this.registerForm = fb.group({
      email: ['', [Validators.required, Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$')]],
      password: ['', Validators.required],
      password_retype: ['', Validators.required]
    }, {
      validator: confirmPassword('password', 'password_retype')
    });

    this.loginForm = fb.group({
      email: ['', [Validators.required, Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$')]],
      password: ['', Validators.required]
    });
  }

  ngOnInit(): void {
  }

  // tslint:disable-next-line:typedef
  createAccount() {
    this.service.emailExist(this.registerForm.value.email).subscribe((data) => {
      if (!data) {
        this.service.register(this.registerForm.value).subscribe(() => {
          this.router.navigateByUrl('/');
        }, error => {
          console.log(error);
        });
      } else {
        console.log('Cet email existe');
      }
    });
  }

  // tslint:disable-next-line:typedef
  onSubmitLogin() {
    this.service.login(this.loginForm.value).subscribe(() => {
      this.router.navigateByUrl('user');
    }, error => {
      console.log(error);
    });
  }
}
