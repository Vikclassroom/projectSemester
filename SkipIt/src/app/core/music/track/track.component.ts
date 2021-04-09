import {Component, Input, OnInit} from '@angular/core';
import {ServicesService} from '../../service/services.service';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';

@Component({
  selector: 'app-track',
  templateUrl: './track.component.html',
  styleUrls: ['./track.component.scss']
})
export class TrackComponent implements OnInit {
  @Input() track: any;

  constructor(private services: ServicesService) {}

  ngOnInit(): void {

  }

  // tslint:disable-next-line:typedef
  addToList() {
    const values = {
      title: this.track.title,
      artist: this.track.artists[0].alias
    };
    this.services.createMusic(values).subscribe();
  }
}
