import { Inject, Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable()
export class ProductService {
    constructor(
        private http: HttpClient, 
        @Inject('BASE_URL') private baseUrl: string) {
    }

    public getProduct(id: number) : Observable<Product> {
        return this.http.get<Product>(this.baseUrl + 'api/product/' + id);
    }

    public getProducts() : Observable<ProductItem[]> {
        return this.http.get<ProductItem[]>(this.baseUrl + 'api/product');
    }
}