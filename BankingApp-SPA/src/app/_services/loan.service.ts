import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { LoanType } from '../_models/loan-type';
import { Observable } from 'rxjs';
import { Transaction } from '../_models/transaction';
import { LoanRequest } from '../_models/loan-request';
import { PaginatedRequest } from '../_models/pagination/paginated-request';
import { PagedResult } from '../_models/pagination/paged-result';

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

  getAllLoanRequests(pagedRequest: PaginatedRequest): Observable<PagedResult<LoanRequest>> {
    return this.http.post<PagedResult<LoanRequest>>(this.baseUrl + 'loan/allrequests', pagedRequest);
  }

  acceptLoanRequest(id: number, model: any): Observable<LoanRequest> {
    return this.http.post<LoanRequest>(this.baseUrl + 'loan/accept/' + id, model);
  }

  rejectLoanRequest(id: number): Observable<LoanRequest> {
    return this.http.post<LoanRequest>(this.baseUrl + 'loan/reject/' + id, {});
  }
}
