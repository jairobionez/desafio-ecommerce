import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { IndexComponent } from './pages/index/index.component';
import { CadProductComponent } from './components/cad-product/cad-product.component';
import { ProductsComponent } from './components/products/products.component';
import { FullscreenOverlayContainer } from '@angular/cdk/overlay';


const routes: Routes = [
  {
    path: 'index', component: IndexComponent, children: [
      {
        path: 'register', component: CadProductComponent
      },
      {
        path: 'products', component: ProductsComponent
      }
    ]
  },
  {
    path: '', redirectTo: 'index/products'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EcommerceRoutingModule { }
