import {
  Component,
  OnInit,
  ElementRef,
  ViewChildren,
  QueryList,
  Output,
  EventEmitter
} from "@angular/core";
import { EcommerceService } from "../../services/ecommerce.service";
import { Product } from "../../models/product.entity";
import { catchError } from "rxjs/operators";
import { throwError } from "rxjs";
import { CartActionEnum } from "../../enums/cart-aciton.enum";
import { CartService } from "../../services/cart.service";
import { MatSnackBar } from "@angular/material";

@Component({
  selector: "products",
  templateUrl: "./products.component.html",
  styleUrls: ["./products.component.scss"]
})
export class ProductsComponent implements OnInit {
  @ViewChildren("amount") amount: QueryList<ElementRef>;

  products: Product[] = [];
  breakpoint: any;

  constructor(
    private _ecommerceService: EcommerceService,
    private _cartService: CartService,
    private _snackBar: MatSnackBar
  ) {}

  ngOnInit() {
    this.loadProducts();
    this.onResize(window);    
  }

  onResize(event) {
    if (event.innerWidth <= 600) this.breakpoint = 1;
    else if (event.innerWidth <= 900) this.breakpoint = 2;
    else if (event.innerWidth <= 1100) this.breakpoint = 3;
    else if (event.innerWidth <= 1700) this.breakpoint = 4;
    else this.breakpoint = 6;
  }

  loadProducts(): void {
    this._ecommerceService
      .getProducts()
      .pipe(
        catchError(err => {
          return throwError(err);
        })
      )
      .subscribe(response => {
        this.products = response;
      });
  }

  add(amount: ElementRef, product: Product) {
    let amountCard = this.amount.find(p => p.nativeElement == amount);

    if (<number>amountCard.nativeElement.value < product.amount) {
      <number>amountCard.nativeElement.value++;

      this._cartService.subjectCart.next({
        action: CartActionEnum.Adicionar,
        product: product
      });
    } else
      this._snackBar.open(
        "A quantidade solicitada do produto não esta disponível",
        "Alerta",
        { duration: 3000 }
      );
  }

  remove(amount: ElementRef, product: Product) {
    let amountCard = this.amount.find(p => p.nativeElement == amount);

    if (<number>amountCard.nativeElement.value > 0) {
      <number>amountCard.nativeElement.value--;

      this._cartService.subjectCart.next({
        action: CartActionEnum.Remover,
        product: product
      });
    }
  }
}
