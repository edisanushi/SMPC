import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

interface Organigram {
  name: string;
  dateCreated: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public forecasts: WeatherForecast[] = [];
  public test: string = "";
  public organigram: Organigram[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    //this.getForecasts();
    //this.getOrganigram();
  }

  getForecasts() {
    this.http.get<WeatherForecast[]>('/weatherforecast').subscribe(
      (result) => {
        this.forecasts = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

 getOrganigrams() {
  this.http.get<Organigram[]>('/Test/GetOrganigram').subscribe(
    (result) => {
      this.organigram = result;
      console.log(this.organigram)
    },
    (error) => {
      console.error(error);
    }
  );
}

  title = 'smpc.client';
}
