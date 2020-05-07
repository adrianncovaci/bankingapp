import { Injectable } from "@angular/core";
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { catchError } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { ExchangeRate } from '../_models/exchangerate';
import { TransferService } from '../_services/transfer.service';

@Injectable()
export class ExchangeRateResolver implements Resolve<ExchangeRate> {
    constructor(private transferService: TransferService, private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<ExchangeRate> {
        return this.transferService.getExchangeRate().pipe(
            catchError( error => {
                this.alertify.error("Problem retrieving data");
                this.router.navigate(['/login']);
                return of(null);
            })
        );
    }

}