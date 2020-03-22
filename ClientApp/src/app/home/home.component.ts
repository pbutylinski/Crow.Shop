import { Component, } from '@angular/core';
import { ProductService } from 'src/services/product.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  providers: [ProductService]
})
export class HomeComponent {
  public products: Product[];

  constructor(private productService: ProductService) {
    this.productService.getProducts().subscribe(data => {
      this.products = data;
    });
  }
}
