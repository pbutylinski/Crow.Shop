import { Inject, Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Injectable()
export class ProductService {
    constructor(
        private http: HttpClient,
        @Inject('BASE_URL') private baseUrl: string) {
    }

    public async getProduct(id: number): Promise<Product> {
        return this.http.get<Product>(this.baseUrl + 'api/product/' + id)
            .toPromise()
            .then(data => {
                data.images = data.images.sort((a, b) => a.order - b.order);
                data.optionGroups = data.optionGroups.sort((a, b) => a.order - b.order);
                data.optionGroups.forEach(x => { x.options = x.options.sort((a, b) => a.order - b.order); });

                return data;
            });
    }

    public async getProducts(): Promise<ProductItem[]> {
        return this.http.get<ProductItem[]>(this.baseUrl + 'api/product').toPromise();
    }
}