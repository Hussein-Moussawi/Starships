import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class StarshipService {

  constructor(private http: HttpClient) { }

  GetStarships(distance) {
    return this.http.get('api/starship/stops?distance=' + distance)
      .pipe(map(res => res));
  }
}
