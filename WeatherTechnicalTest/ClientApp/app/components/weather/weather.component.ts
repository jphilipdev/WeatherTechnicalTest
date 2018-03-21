import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { DatePipe } from '@angular/common';

@Component({
    selector: 'weather',
    templateUrl: './weather.component.html',
    styleUrls: ['./weather.component.css']
})
export class WeatherComponent {
    public country: string;
    public cities: string[];
    public city: string;
    public weather: Weather;

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) { }

    public getCities() {
        this.http.get(this.baseUrl + 'api/country/' + this.country + '/cities').subscribe(result => {
            this.cities = result.json() as string[];
        }, error => console.error(error));
    }

    public onCityChange() {
        this.http.get(this.baseUrl + 'api/country/' + this.country + '/cities/' + this.city + '/weather').subscribe(result => {
            this.weather = result.json() as Weather;
        }, error => console.error(error));
    }
}

interface Weather {
    location: string,
    time: Date,
    wind: string,
    visibility: string,
    skyConditions: string,
    temperature: number,
    dewPoint: number,
    relativeHumidity: number,
    pressure: number
}