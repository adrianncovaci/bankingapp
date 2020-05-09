import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router, NavigationEnd } from '@angular/router';
import { LoanRequest } from 'src/app/_models/loan-request';
import { LoanType } from 'src/app/_models/loan-type';
import { LoanService } from 'src/app/_services/loan.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { TableColumn } from 'src/app/_models/pagination/table-column';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { FormBuilder } from '@angular/forms';
import { PaginatedRequest } from '../../_models/pagination/paginated-request'; 
import { PagedResult } from '../../_models/pagination/paged-result'; 
import { RequestFilters } from 'src/app/_models/pagination/request-filters';
import { merge } from 'rxjs';

interface LoanRow {
  loanName: string;
  customerName: string;
  dateIssued: Date;
  status: string;
  comments: string;
}

@Component({
  selector: 'app-officer-panel',
  templateUrl: './officer-panel.component.html',
  styleUrls: ['./officer-panel.component.css']
})
export class OfficerPanelComponent implements AfterViewInit {
  pagedLoans: PagedResult<LoanRequest>;

  tableColumns: TableColumn[] = [
    { name: 'loanName', displayName: 'Loan', index: 'loanName', useInSearch: true },
    { name: 'customerName', displayName: 'Customer CNP', index: 'customerName', useInSearch: true },
    { name: 'dateIssued', displayName: 'Date Issued', index: 'dateIssued', useInSearch: true },
    { name: 'status', displayName: 'Status', index: 'status', useInSearch: true },
    { name: 'comments', displayName: 'Comments', index: 'comments', useInSearch: false },
    { name: 'id', displayName: 'Actions', index: 'id', useInSearch: true }
  ];
  displayedColumns: string[];
  loanRequests: LoanRequest[];
  loanTypes: LoanType[];
  navigationSubscription;
  requestFilters: RequestFilters;

  @ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;
  @ViewChild(MatSort, { static: false}) sort: MatSort;

  constructor(private activeRouter: ActivatedRoute, private loanService: LoanService, private alertify: AlertifyService, private fb: FormBuilder) {
    this.displayedColumns = this.tableColumns.map(el => el.name);
  }

  ngAfterViewInit(): void {
    this.loadBooks();
    this.sort.sortChange.subscribe( () => this.paginator.pageIndex = 0 );

    merge(this.sort.sortChange, this.paginator.page).subscribe(() => {
      this.loadBooks();
    });
  }

  loadBooks() {
    const request = new PaginatedRequest(this.paginator, this.sort, this.requestFilters);
    console.log(request);
    this.loanService.getAllLoanRequests(request).subscribe((loans: PagedResult<LoanRequest>) => {
      console.log(loans);
      this.pagedLoans = loans;
    });
  }

  acceptLoanRequest(id: number) {
    this.loanService.acceptLoanRequest(id).subscribe(next => {
      this.alertify.success("Successfully accepted");
    },
    error => {
      this.alertify.error("Something went wrong");
    });
  }

  rejectLoanRequest(id: number) {
    this.loanService.rejectLoanRequest(id).subscribe(next => {
      this.alertify.success("Successfully rejected");
    },
    error => {
      this.alertify.error("Something went wrong");
    });
  }
}
