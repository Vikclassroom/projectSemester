import { Component, OnInit } from '@angular/core';
import {ServicesService} from '../service/services.service';
import {IMusic} from '../../shared/models/music';

@Component({
  selector: 'app-my-list',
  templateUrl: './my-list.component.html',
  styleUrls: ['./my-list.component.css']
})
export class MyListComponent implements OnInit {
  music: {};
  id = localStorage.getItem('id');

  constructor(private services: ServicesService) { }

  ngOnInit(): void {
    this.services.getMusic().subscribe((data: IMusic) => {
      this.music = data;
    });
  }

  // tslint:disable-next-line:typedef
  deleteMusic(idMusic: number) {
    this.services.deleteMusic(idMusic).subscribe();
    window.location.reload();
  }
}
