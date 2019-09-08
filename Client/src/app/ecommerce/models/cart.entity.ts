import { Product } from './product.entity';

export class Cart {
  constructor(product: Product) {
	  this.id = product.id;
	  this.amount = 1;
	  this.unitPrice = product.value;
	  this.description = product.description;
  }

  id: number;
  amount: number;
  unitPrice: number;
  description: string;
}
