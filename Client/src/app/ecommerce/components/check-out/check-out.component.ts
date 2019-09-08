import { Component, OnInit, ViewEncapsulation } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { MatDialogRef, MatDialog, MatSnackBar } from "@angular/material";
import { EcommerceService } from "../../services/ecommerce.service";
import { CartPaymentService } from "../../services/cart-payment.service";
import { Cart } from "../../models/cart.entity";
import { Payment } from "../../models/payment.entity";
import { catchError, delay } from "rxjs/operators";
import { throwError, empty, of } from "rxjs";

@Component({
  selector: "app-check-out",
  templateUrl: "./check-out.component.html",
  styleUrls: ["./check-out.component.scss"],
  encapsulation: ViewEncapsulation.None
})
export class CheckOutComponent implements OnInit {
  formBuyer: FormGroup;
  formPayment: FormGroup;

  paymentModel: Payment;
  cart: Cart[] = [];
  isCredit: boolean = false;

  constructor(
    public checkOutDialogRef: MatDialogRef<CheckOutComponent>,
    public dialog: MatDialog,
    private _fb: FormBuilder,
    private _ecommerceService: EcommerceService,
    private _snackBar: MatSnackBar,
    private _cartPayment: CartPaymentService
  ) {
    this.createForm();

    this._cartPayment.subjectCart$.subscribe(response => {
      this.cart = response;
    });
  }

  ngOnInit() {}

  createForm() {
    this.formBuyer = this._fb.group({
      firstName: [null, Validators.required],
      lastName: [null, Validators.required],
      street: [null, Validators.required],
      city: [null, Validators.required],
      state: [null, Validators.required],
      zipCode: [null, Validators.required],
      neighborhood: null,
      number: [null, Validators.required],
      email: [null, [Validators.email, Validators.required]],
      country: [null, Validators.required],
      document: [null, Validators.required]
    });

    this.formPayment = this._fb.group({
      cardHolderName: [null, Validators.required],
      cardNumber: [null, Validators.required],
      securityCode: [null, Validators.required],
      validDate: [null, Validators.required]
    });
  }

  payment(): void {
    if (!this.formPayment.valid && this.isCredit) {
      this._snackBar.open(
        "Por favor, verifique se os dados do cartão estão corretos",
        "Alerta",
        { duration: 3000 }
      );
      return;
    }

    if (this.formBuyer.valid) {
      this.paymentModel = new Payment(
        this.buyerControls["firstName"].value,
        this.buyerControls["lastName"].value,
        this.buyerControls["street"].value,
        this.buyerControls["city"].value,
        this.buyerControls["state"].value,
        this.buyerControls["zipCode"].value,
        this.buyerControls["neighborhood"].value,
        this.buyerControls["number"].value,
        this.buyerControls["document"].value,
        this.paymentControls["cardHolderName"].value,
        this.paymentControls["cardNumber"].value,
        this.paymentControls["securityCode"].value,
        this.paymentControls["validDate"].value,
        this.cart,
        this.totalCart(),
        this.totalWithDiscount(),
        this.buyerControls["country"].value,
        this.buyerControls["email"].value
      );

      if (this.isCredit)
        this._ecommerceService
          .paymentCreditCard(this.paymentModel)
          .pipe(
            catchError(err => {
              let error: string = "";
              err.error.errors.forEach(element => {
                error += element.notificacao + "\n"
              });

              this._snackBar.open(error,"Alerta",{ duration: 6000 });

              return throwError(err);
            })
          )
          .subscribe(response => {
            this.paymentFinish();
          });
      else
        this._ecommerceService
          .paymentBoleto(this.paymentModel)
          .pipe(
            catchError(err => {
              return throwError(err);
            })
          )
          .subscribe(response => {
            this.paymentFinish();
          });
    } else {
      this._snackBar.open("Por favor, verifique se os dados do comprador estão corretos","Alerta",{ duration: 3000 });
    }
  }

  choseForm(event) {
    this.isCredit = event;
  }

  public get paymentControls() {
    return this.formPayment.controls;
  }

  public get buyerControls() {
    return this.formBuyer.controls;
  }

  public totalProduct(product: Cart): number {
    return product.amount * product.unitPrice;
  }

  public totalCart(): number {
    let total: number = 0;
    this.cart.forEach(item => {
      total += this.totalProduct(item);
    });

    return total;
  }

  totalWithDiscount(): number {
    let total = this.totalCart();
    if (!this.isCredit) return (total -= total * 0.05);
    return total;
  }

  cancel(): void {
    this.checkOutDialogRef.close();
    this.formBuyer.reset();
    this.formPayment.reset();
  }

  paymentFinish(): void {
    this.cancel();
    this.cart = [];
    this._cartPayment.paymentFinish.next();
    this._snackBar.open("Pagamento realizado com sucesso!","Alerta",{ duration: 3000 });
    
    setTimeout(() => {
      window.location.reload();
    }, 3000);    
  }
}
