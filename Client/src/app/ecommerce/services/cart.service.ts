import { Injectable } from "@angular/core";
import { Subject } from 'rxjs';

@Injectable()
export class CartService {
    subjectCart: Subject<any> = new Subject<any>();
    subjectCart$ = this.subjectCart.asObservable();
}