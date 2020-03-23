import { Component, OnInit, } from '@angular/core';
import { ProductService } from 'src/services/product.service';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-product',
    templateUrl: './product.component.html',
    styleUrls: ['./product.component.css'],
    providers: [ProductService]
})
export class ProductComponent implements OnInit {
    public product: Product;
    public currentImage: ProductImage;

    constructor(
        private productService: ProductService,
        private route: ActivatedRoute) {
    }

    ngOnInit(): void {
        this.route.paramMap.subscribe(params => {
            const id = parseInt(params.get("id"));

            this.productService.getProduct(id).then(data => {
                this.product = data;
                this.currentImage = this.product.images[0];
            });
        });
    }
}
