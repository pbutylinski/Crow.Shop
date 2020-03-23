import { Component, OnInit, } from '@angular/core';
import { ProductService } from 'src/services/product.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  providers: [ProductService]
})
export class HomeComponent implements OnInit {
  public products: ProductItem[];

  constructor(private productService: ProductService) {
  }

  ngOnInit(): void {
    this.productService.getProducts().then(data => {
      this.products = data;
    });
  }
}
