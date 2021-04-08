import { Component, OnInit } from '@angular/core';
import { AuthService} from '../service/auth.service';
import {FormGroup, FormControl, Validators, FormBuilder} from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import {confirmPassword} from './confirmPassword';


@Component({
  selector: 'app-sign',
  templateUrl: './sign.component.html',
  styleUrls: ['./sign.component.scss']
})

export class SignComponent implements OnInit {
  registerForm: FormGroup ;

  loginForm = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$')]),
    password: new FormControl('', Validators.required)
  });

  constructor(private service: AuthService, private router: Router, private activatedRoute: ActivatedRoute, private fb: FormBuilder) {
    this.registerForm = fb.group({
      email: ['', [Validators.required, Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$')]],
      password: ['', Validators.required],
      password_retype: ['', Validators.required]
    }, {
      validator: confirmPassword('password', 'password_retype')
    });
  }

  ngOnInit(): void {
  }

  // tslint:disable-next-line:typedef
  createAccount(){
    this.service.register(this.registerForm.value);
  }

  // tslint:disable-next-line:typedef
  onSubmitLogin() {
    this.service.login(this.loginForm.value);
  }
}
