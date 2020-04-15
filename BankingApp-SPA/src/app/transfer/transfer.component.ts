import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-transfer',
  templateUrl: './transfer.component.html',
  styleUrls: ['./transfer.component.css']
})
export class TransferComponent implements OnInit {
  values: any;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getValues();
  }

  getValues() {
    this.http.get('http://localhost:5000/transfer').subscribe(response => {
      this.values = response;
    }), error => {
      console.log(error);
    };
  }

}
