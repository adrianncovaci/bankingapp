export interface PagedResult<T> {
    pageNumber: number;
    pageSize: number;
    total: number;
    data: T[];
}