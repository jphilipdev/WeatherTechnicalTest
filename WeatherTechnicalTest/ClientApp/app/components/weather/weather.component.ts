import { Component } from '@angular/core';

@Component({
    selector: 'weather',
    templateUrl: './weather.component.html'
})
export class WeatherComponent {
    public currentCount = 0;

    public incrementCounter() {
        this.currentCount++;
    }
}
