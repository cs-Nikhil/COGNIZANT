import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'creditLabel',
  standalone: true
})
export class CreditLabelPipe implements PipeTransform {
  transform(credits: number): string {
    return `${credits} ${credits === 1 ? 'credit' : 'credits'}`;
  }
}

