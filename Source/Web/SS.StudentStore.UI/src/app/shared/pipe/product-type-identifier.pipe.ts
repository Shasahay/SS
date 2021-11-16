import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'productTypeIdentifier'
})
export class ProductTypeIdentifierPipe implements PipeTransform {

  transform(value: number, ...args: unknown[]): string {
    return this.getProductType(value);
  }
getProductType(value: number): string{
  switch(value){
    case 1: 
    return 'Paperback';
    case 2: 
    return 'Ebook';
    case 3:
      return 'Subscribe'
      default:
        return undefined;
  }
}
}
