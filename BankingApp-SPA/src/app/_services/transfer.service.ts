import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TransferService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  withdraw(model: any) {
    return this.http.post(this.baseUrl + 'bankaccount/withdraw', model);
  }

  deposit(model: any) {
    return this.http.post(this.baseUrl + 'bankaccount/deposit', model);
  }

  transfer(model: any) {
    return this.http.post(this.baseUrl + 'bankaccount/transfer', model);
  }
}
