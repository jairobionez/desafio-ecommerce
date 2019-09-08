import { Component, OnInit, ViewEncapsulation, ViewChild } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { EcommerceService } from "../../services/ecommerce.service";
import { catchError, finalize, tap } from "rxjs/operators";
import { throwError } from "rxjs";
import { Product } from "../../models/product.entity";
import {
  MatSnackBar,
  MatPaginator,
  MatTableDataSource
} from "@angular/material";
import { InputFile } from "../../models/input-file.entity";

@Component({
  selector: "cad-product",
  templateUrl: "./cad-product.component.html",
  styleUrls: ["./cad-product.component.scss"],
  encapsulation: ViewEncapsulation.None
})
export class CadProductComponent implements OnInit {
  @ViewChild("ProductPaginator", { static: false }) paginator: MatPaginator;
  dataSource = new MatTableDataSource<Product>();

  form: FormGroup;
  products: Product[] = [];

  isLoad: boolean = false;

  b64image: InputFile[] = [];

  selected: Product = new Product();

  displayedColumns: string[] = [
    "id",
    "description",
    "weight",
    "value",
    "amount",
    "eanCode",
    "image"
  ];

  constructor(
    private _fb: FormBuilder,
    private _ecommerceService: EcommerceService,
    private _snackBar: MatSnackBar
  ) {
    this.createForm();
  }

  ngOnInit() {
    this.loadProducts();
  }

  createForm(): void {
    this.form = this._fb.group({
      id: 0,
      description: [null, [Validators.required, Validators.maxLength(50)]],
      image: null,
      value: [0, [Validators.required, Validators.min(0.01)]],
      weight: [0, [Validators.required, Validators.min(0.01)]],
      amount: [0, Validators.required],
      eanCode: [null, [Validators.required, Validators.maxLength(13)]]
    });
  }

  loadProducts(): void {
    this.isLoad = true;
    this._ecommerceService
      .getProducts()
      .pipe(
        finalize(() => (this.isLoad = false)),
        catchError(err => {
          return throwError(err);
        })
      )
      .subscribe((response: any) => {
        this.dataSource = new MatTableDataSource(response.data)
        this.setPaginator();
      });
  }

  save(): void {
    if (this.form.valid) {
      this.isLoad = true;
      this.convertImageToBase64();

      this._ecommerceService
        .saveProduct(this.form.value)
        .pipe(
          finalize(() => {
            this.isLoad = false;
            this.loadProducts();
            this.reset();
          }),
          catchError(err => {
            this._snackBar.open("Não foi possível salvar o produto", "Fechar", {
              duration: 3000
            });
            return throwError(err);
          })
        )
        .subscribe(response => {
          this._snackBar.open("Produto salvo com sucesso", "Fechar", {
            duration: 3000
          });
        });
    } else {
      this._snackBar.open(
        "Formulária inválido, por favor verifique os campos e imagem",
        "Fechar",
        {
          duration: 3000
        }
      );
    }
  }

  delete(): void {
    if (this.form.valid) {
      this.isLoad = true;

      this._ecommerceService
        .deleteProduct(this.selected.id)
        .pipe(
          finalize(() => {
            this.loadProducts();
            this.reset();
            this.isLoad = false;
          }),
          catchError(err => {
            this._snackBar.open(
              "Não foi possível deletar o produto",
              "Fechar",
              {
                duration: 3000
              }
            );
            return throwError(err);
          })
        )
        .subscribe(response => {
          this._snackBar.open("Produto deletado com sucesso", "Fechar", {
            duration: 3000
          });
        });
    } else {
      this._snackBar.open(
        "Formulária inválido, por favor verifique os campos e imagem",
        "Fechar",
        {
          duration: 3000
        }
      );
    }
  }

  update(): void {
    if (this.form.valid) {
      this.isLoad = true;

      this._ecommerceService
        .updateProduct(this.form.value)
        .pipe(
          finalize(() => {
            this.isLoad = false;
            this.loadProducts();
            this.reset();
          }),
          catchError(err => {
            this._snackBar.open(
              "Não foi possível atualizar o produto",
              "Fechar",
              {
                duration: 3000
              }
            );
            return throwError(err);
          })
        )
        .subscribe(response => {
          this._snackBar.open("Produto atualizado com sucesso", "Fechar", {
            duration: 3000
          });
        });
    } else {
      this._snackBar.open(
        "Formulária inválido, por favor verifique os campos e imagem",
        "Fechar",
        {
          duration: 3000
        }
      );
    }
  }

  public get controls() {
    return this.form.controls;
  }

  convertImageToBase64(): void {
    this.controls["image"].setValue(this.b64image[0].preview);
  }

  sendToForm(row) {
    this.b64image = [];
    this.selected = row;
    this.b64image.push(new InputFile(null, this.selected.image));
    this.form.setValue(this.selected);
  }

  clear(): void {
    this.form.reset();
    this.b64image = [];
    this.selected = new Product();
  }

  reset(): void {
    this.b64image = [];
    this.form.reset();
    this.form.setValidators(null);
  }

  setPaginator() {
    this.dataSource.paginator = this.paginator;
  }
}