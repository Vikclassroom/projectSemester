import { Component, OnInit } from '@angular/core';
import {Observable} from 'rxjs';
import {ArtistsService} from './artists.service';
import {ChartParams} from './chartParams';

@Component({
  selector: 'app-artists',
  templateUrl: './artists.component.html',
  styleUrls: ['./artists.component.scss']
})
export class ArtistsComponent implements OnInit {
  artist$: Observable<ChartParams>;
  tracks: [];

  constructor(private artistService: ArtistsService) { }

  ngOnInit(): void {
    this.artistService.getChartList().subscribe((chart: ChartParams) => {
      this.tracks = chart.tracks;
      console.log(this.tracks);
    });
  }
}
