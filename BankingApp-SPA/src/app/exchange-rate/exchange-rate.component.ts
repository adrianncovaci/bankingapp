import { Component, OnInit } from '@angular/core';
import { ExchangeRate } from '../_models/exchangerate';
import { LoanService } from '../_services/loan.service';
import { AlertifyService } from '../_services/alertify.service';
import { ActivatedRoute } from '@angular/router';

export interface Currency {
  position: number;
  currency: string;
  value: number;
}

@Component({
  selector: 'app-exchange-rate',
  templateUrl: './exchange-rate.component.html',
  styleUrls: ['./exchange-rate.component.css']
})
export class ExchangeRateComponent implements OnInit {
  collumns: string[] = ["position", "currency", "value"];
  exchangeRate: ExchangeRate;
  currencies: Currency[] = [];
  constructor(private alertify: AlertifyService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.exchangeRate = data['exchangeRate'];
      let index = 1
      for(const key in this.exchangeRate.rates) {
        this.currencies.push({ position: index, currency: key, value: this.exchangeRate.rates[key] });
        index += 1;
      }
    })
  }

}
