import { Component, } from '@angular/core';
import { ProductService } from 'src/services/product.service';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-product',
    templateUrl: './product.component.html',
    providers: [ProductService]
})
export class ProductComponent {
    public product: Product;

    constructor(
        private productService: ProductService,
        private route: ActivatedRoute) {
            
        this.route.paramMap.subscribe(params => {
            const id = parseInt(params.get("id"));

            this.productService.getProduct(id).subscribe(data => {
                this.product = data;
            });
        });
    }
}
