import { Directive, ElementRef, HostListener, Input, Renderer2 } from '@angular/core';

@Directive({
  selector: '[appHighlight]',
  standalone: true
})
export class HighlightDirective {
  @Input('appHighlight') accentColor = '#7c5cff';

  constructor(
    private readonly elementRef: ElementRef<HTMLElement>,
    private readonly renderer: Renderer2
  ) {}

  @HostListener('mouseenter')
  onMouseEnter(): void {
    const element = this.elementRef.nativeElement;
    this.renderer.setStyle(element, 'transform', 'translateY(-4px)');
    this.renderer.setStyle(element, 'boxShadow', `0 18px 40px color-mix(in srgb, ${this.accentColor} 22%, transparent)`);
    this.renderer.setStyle(element, 'borderColor', this.accentColor);
  }

  @HostListener('mouseleave')
  onMouseLeave(): void {
    const element = this.elementRef.nativeElement;
    this.renderer.removeStyle(element, 'transform');
    this.renderer.removeStyle(element, 'boxShadow');
    this.renderer.removeStyle(element, 'borderColor');
  }
}

