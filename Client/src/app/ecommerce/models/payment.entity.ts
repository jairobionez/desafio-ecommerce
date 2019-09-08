import { MatNativeDateModule } from '@angular/material';
import { Cart } from './cart.entity';

export class Payment {
  constructor(
    firstName: string,
    lastName: string,
    street: string,
    city: string,
    state: string,
    zipCode: string,
    neighborhood: string,
    number: string,
    document: string,
    cardHolderName: string,
    cardNumber: string,
    securityCode: string,
    validDate: Date,
    products: Cart[],
    total: number,
    totalPaid: number,
    country: string,
    email: string,
  ) {
    this.firstName = firstName
    this.lastName = lastName;
    this.street = street;
    this.city = city;
    this.state = state;
    this.zipCode = zipCode;
    this.neighborhood = neighborhood;
    this.number = number;
    this.document = document;
    this.cardHolderName = cardHolderName;
    this.cardNumber = cardNumber;
    this.securityCode = securityCode;
    this.validDate = validDate;
    this.products = products;
    this.boletoNumber = "00000.00000 00000.000000 00000.000000 0 00000000000000"; // Fake para simular
    this.total = total;
    this.totalPaid = totalPaid;
    this.payerDocumentType = this.documentType(document);
    this.country = country;
    this.email = email;
  }

  firstName: string;
  lastName: string;
  street: string;
  city: string;
  state: string;
  zipCode: string;
  neighborhood: string;
  number: string;
  document: string;
  cardHolderName: string;
  cardNumber: string;
  securityCode: string;
  validDate: Date;
  boletoNumber: string;
  total: number;
  totalPaid: number;
  payerDocumentType: number;
  products: Cart[];
  country: string;
  email: string;

  public documentType(document: string): number{
    if(document.length == 14)
      return 2;
    return 1;
  }
}
