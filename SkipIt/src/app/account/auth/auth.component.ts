import { Component, OnInit } from '@angular/core';
import {IAccount} from '../../shared/models/account';
import {Router} from '@angular/router';
import {AuthService} from '../service/auth.service';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss']
})
export class AuthComponent implements OnInit {
  login = {} as IAccount;
  isWrongCredentials = false;

  constructor(private router: Router, private authService: AuthService) { }

  ngOnInit(): void {
  }

}
