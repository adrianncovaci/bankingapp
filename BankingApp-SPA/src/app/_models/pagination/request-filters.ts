import { FilterOperator } from './filter-operator';
import { Filter } from './filter';

export interface RequestFilters {
    logicalOperator: FilterOperator;
    filters: Filter[];
}