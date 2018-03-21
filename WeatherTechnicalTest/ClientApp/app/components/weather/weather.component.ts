import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'weather',
    templateUrl: './weather.component.html'
})
export class WeatherComponent {
    public country: string;
    public cities: string[];

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) { }

    public getCities() {
        this.http.get(this.baseUrl + 'api/country/' + this.country + '/cities').subscribe(result => {
            this.cities = result.json() as string[];
        }, error => console.error(error));
    }
}

interface RaceDetails {
    race: Race;
    status: string;
    totalPlace: number;
    Horses: HorseDetails[];
}

interface Race {
    id: number;
    name: string;
    start: Date;
    status: string;
    Horses: Horse[]
}

interface Horse {
    id: number;
    name: string;
    odds: string;
}

interface HorseDetails {
    horse: Horse;
    numberOfBets: number;
    totalPotentialPayout: number;
}

