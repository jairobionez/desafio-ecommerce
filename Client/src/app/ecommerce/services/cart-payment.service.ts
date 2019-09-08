import { Injectable } from "@angular/core";
import { Subject } from 'rxjs';
import { Cart } from '../models/cart.entity';

@Injectable()
export class CartPaymentService {
    subjectCart: Subject<Cart[]> = new Subject<Cart[]>();
    subjectCart$ = this.subjectCart.asObservable();

    paymentFinish: Subject<any> = new Subject<any>();
    paymentFinish$ = this.paymentFinish.asObservable();
}