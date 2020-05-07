import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { LoanType } from '../_models/loan-type';
import { Observable } from 'rxjs';
import { Transaction } from '../_models/transaction';
import { LoanRequest } from '../_models/loan-request';

@Injectable({
  providedIn: 'root'
})
export class LoanService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getLoanTypes(): Observable<LoanType[]> {
    return this.http.get<LoanType[]>(this.baseUrl + 'loan/loans');
  }

  requestLoan(model: any): Observable<Transaction> {
    return this.http.post<Transaction>(this.baseUrl + 'loan/request', model);
  }

  getLoanRequestsByCurrentUser(): Observable<LoanRequest[]> {
    return this.http.get<LoanRequest[]>(this.baseUrl + 'loan/requests');
  }
}
