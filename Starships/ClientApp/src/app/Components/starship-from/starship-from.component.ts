import { Component, OnInit } from '@angular/core';
import { StarshipService } from '../../services/starship.service';

@Component({
  selector: 'app-starship-from',
  templateUrl: './starship-from.component.html',
  styleUrls: ['./starship-from.component.css']
})
export class StarshipFromComponent {

  showTable: false;
  starships: any;
  distance: number;

  constructor(private starshipService: StarshipService) {
  }

  validate() {
    if (this.distance > 1000000000000000) {
      alert('Maximum distance exceeded');
      return false;
    }
    else {
      return true;
    }
  }

  GetStarships() {
    if (this.validate()) {
      this.starshipService.GetStarships(this.distance).subscribe(starships => {
        this.starships = starships;
      });
  }
  }
}

