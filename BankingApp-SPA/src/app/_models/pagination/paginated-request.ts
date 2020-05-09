import { RequestFilters } from './request-filters';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';

export class PaginatedRequest {
    pageNumber: number;
    pageSize: number;
    columnNameForSorting: string;
    sortDirection: string;
    requestFilters: RequestFilters;

    constructor(paginator: MatPaginator, sort: MatSort, filters: RequestFilters) {
        this.pageNumber = paginator.pageIndex + 1;
        this.pageSize = paginator.pageSize;
        this.columnNameForSorting = sort.active;
        this.sortDirection = sort.direction;
        this.requestFilters = filters;
    }
}