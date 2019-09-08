import { Component, OnInit } from "@angular/core";
import { Cart } from "../../models/cart.entity";
import { CartActionEnum } from "../../enums/cart-aciton.enum";
import { Product } from "../../models/product.entity";
import { Router, NavigationEnd } from "@angular/router";
import { CartService } from "../../services/cart.service";
import { MatSnackBar, MatDialog, MatDialogRef } from "@angular/material";
import { CheckOutComponent } from "../../components/check-out/check-out.component";
import { CartPaymentService } from '../../services/cart-payment.service';

@Component({
  selector: "index",
  templateUrl: "./index.component.html",
  styleUrls: ["./index.component.scss"]
})
export class IndexComponent implements OnInit {
  cart: Cart[] = [];
  inCadProd: boolean = false;
  checkOutDialogRef: MatDialogRef<CheckOutComponent>;

  constructor(
    private _router: Router,
    private _cartService: CartService,
    private _cartPayment: CartPaymentService,
    public dialog: MatDialog,
    private _snackBar: MatSnackBar
  ) {
    this.inCadProd = this._router.isActive("/index/register", true);
  }
  ngOnInit() {
    this._cartService.subjectCart$.subscribe(response => {
      this.addCart(response);
    });

    this._cartPayment.paymentFinish$.subscribe(response => {
      this.cart = [];
    })

    this._router.events.subscribe(response => {
      if (response instanceof NavigationEnd) {
        this.inCadProd = this._router.isActive("/index/register", true);
      }
    });
  }

  addCart(event: any): void {
    switch (event.action) {
      case CartActionEnum.Adicionar:
        if (!this.productExistInCart(event.product))
          this.cart.push(new Cart(event.product));
        else this.amountUpdate(event);
        break;
      case CartActionEnum.Remover:
        let prod = this.cart.find(p => p.id == event.product.id);

        if (prod!.amount == 1) {
          let index = this.cart.findIndex(p => p.id == event.product.id);
          this.cart.splice(index, 1);
        } else if (prod) this.amountUpdate(event);
        break;
    }
  }

  productExistInCart(product: Product): boolean {
    let has = this.cart.find(p => p.id == product.id);

    return has != null;
  }

  amountUpdate(event: any): void {
    switch (event.action) {
      case CartActionEnum.Adicionar:
        this.cart.find(p => p.id == event.product.id).amount++;
        break;
      case CartActionEnum.Remover:
        this.cart.find(p => p.id == event.product.id).amount--;
        break;
    }
  }

  navigateTo(event: number): void {
    switch (event) {
      case 1:
        this._router.navigateByUrl("index/register");
        break;
      case 2:
        this._router.navigateByUrl("index/products");
        break;
    }
  }

  openCheckOutDialog() {
    if (this.cart.length > 0){
      this.checkOutDialogRef = this.dialog.open(CheckOutComponent, {
        hasBackdrop: true,
        disableClose: true,
        height: "40rem",
        width: "60rem"
      });

      this._cartPayment.subjectCart.next(this.cart);
    }
    else
      this._snackBar.open(
        "Não há itens no carrinho",
        "Alerta",
        { duration: 3000 }
      );
  }
}
