import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'priceDifference' })
export class PriceDifferencePipe implements PipeTransform {
  transform(value: number): string {
    if (value > 0) {
      return "+" + value;
    }

    if (value < 0) {
      return value.toString();
    }

    return "";
  }
}