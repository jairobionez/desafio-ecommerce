import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { IndexComponent } from "./pages/index/index.component";
import { EcommerceRoutingModule } from "./ecommerce-routing.module";
import { MatMenuModule } from "@angular/material/menu";
import {
  MatToolbarModule,
  MatSidenavModule,
  MatListModule,
  MatButtonModule,
  MatIconModule
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

const config: InputFileConfig = {};

const COMPONENTS = [IndexComponent, ProductsComponent, CadProductComponent];

const SERVICES = [EcommerceService, CartService];

@NgModule({
  declarations: [...COMPONENTS],
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
    MatPaginatorModule
  ],
  exports: [...COMPONENTS],
  providers: [...SERVICES]
})
export class EcommerceModule {}
