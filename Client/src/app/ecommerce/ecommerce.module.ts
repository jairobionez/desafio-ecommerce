import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IndexComponent } from './pages/index/index.component'; 
import { EcommerceRoutingModule } from './ecommerce-routing.module';
import {MatButtonModule} from '@angular/material/button';

const COMPONENTS = [
  IndexComponent
];

@NgModule({
  declarations: [...COMPONENTS],
  imports: [
    CommonModule,
    EcommerceRoutingModule,
    MatButtonModule
  ],
  exports: [
    ...COMPONENTS
  ]
})
export class EcommerceModule { }
