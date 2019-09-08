import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Observable, pipe } from 'rxjs';
import { map } from 'rxjs/operators'
import { Product } from '../models/product.entity';

@Injectable()
export class EcommerceService {
    constructor(private _http: HttpClient) {    
        
    }

    public getProducts(): Observable<Product[]> {
        return this._http.get(this.ecommercerUrls['products'])
            .pipe(
                map((data: Product[]) => {
                    return data;
                })
            );
    }

    public saveProduct(data: Product): Observable<Product> {
        return this._http.post(this.ecommercerUrls['products'], data)
            .pipe(
                map((data: Product) => {
                    return data;
                })
            );
    }

    public updateProduct(data: Product): Observable<string> {
        return this._http.put(this.ecommercerUrls['products'], data)
            .pipe(
                map((data: string) => {
                    return data;
                })
            );
    }

    public deleteProduct(id: number): Observable<string> {
        return this._http.delete(this.ecommercerUrls['products'] + id)
            .pipe(
                map((data: string) => {
                    return data;
                })
            );
    }

    private get ecommercerUrls() {
        return {
            "products": "https://localhost:44316/api/product/"
        }
    }
}