import { NgModule, LOCALE_ID } from "@angular/core";
import { CommonModule, registerLocaleData } from "@angular/common";
import { IndexComponent } from "./pages/index/index.component";
import { EcommerceRoutingModule } from "./ecommerce-routing.module";
import { MatMenuModule } from "@angular/material/menu";
import {
  MatToolbarModule,
  MatSidenavModule,
  MatListModule,
  MatButtonModule,
  MatIconModule,
  MAT_DATE_LOCALE,
  MatNativeDateModule
} from "@angular/material";
import { FlexLayoutModule } from "@angular/flex-layout";
import { MatBadgeModule } from "@angular/material/badge";
import { ProductsComponent } from "./components/products/products.component";
import { EcommerceService } from "./services/ecommerce.service";
import { MatCardModule } from "@angular/material/card";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { MatGridListModule } from "@angular/material/grid-list";
import { MatInputModule } from "@angular/material/input";
import { CadProductComponent } from "./components/cad-product/cad-product.component";
import { CartService } from "./services/cart.service";
import { MatSnackBarModule } from "@angular/material/snack-bar";
import { InputFileConfig, InputFileModule } from "ngx-input-file";
import { MatProgressBarModule } from "@angular/material/progress-bar";
import { MatButtonToggleModule } from "@angular/material/button-toggle";
import { MatTableModule } from "@angular/material/table";
import { MatPaginatorModule } from "@angular/material/paginator";
import {
  MatDialogModule,
  MAT_DIALOG_DEFAULT_OPTIONS
} from "@angular/material/dialog";
import { MatStepperModule } from "@angular/material/stepper";
import { CheckOutComponent } from "./components/check-out/check-out.component";
import { MatSelectModule } from "@angular/material/select";
import { MatRadioModule } from "@angular/material/radio";
import { CartPaymentService } from "./services/cart-payment.service";
import { MatDividerModule } from "@angular/material/divider";
import { MatDatepickerModule } from "@angular/material/datepicker";

import localePt from "@angular/common/locales/pt";
registerLocaleData(localePt, "pt");

const config: InputFileConfig = {};

const COMPONENTS = [IndexComponent, ProductsComponent, CadProductComponent];

const SERVICES = [EcommerceService, CartService, CartPaymentService, MatDatepickerModule];

@NgModule({
  declarations: [...COMPONENTS, CheckOutComponent],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    EcommerceRoutingModule,
    MatButtonModule,
    MatSidenavModule,
    MatMenuModule,
    MatToolbarModule,
    MatListModule,
    MatIconModule,
    FlexLayoutModule,
    MatBadgeModule,
    MatCardModule,
    MatGridListModule,
    MatInputModule,
    MatSnackBarModule,
    InputFileModule.forRoot(config),
    MatProgressBarModule,
    MatButtonToggleModule,
    MatTableModule,
    MatPaginatorModule,
    MatDialogModule,
    MatStepperModule,
    MatSelectModule,
    MatRadioModule,
    MatDividerModule,
    MatDatepickerModule,
    MatNativeDateModule 
  ],
  exports: [...COMPONENTS],
  providers: [
    ...SERVICES,
    { provide: MAT_DIALOG_DEFAULT_OPTIONS, useValue: { hasBackdrop: true } },
    { provide: MAT_DATE_LOCALE, useValue: "pt-PT" },
    { provide: LOCALE_ID, useValue: "pt-PT" }
  ],
  entryComponents: [CheckOutComponent]
})
export class EcommerceModule {}
