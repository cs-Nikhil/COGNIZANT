import { Component, inject } from '@angular/core';
import { LoadingService } from '../../services/loading.service';

@Component({
  selector: 'app-loading-indicator',
  standalone: true,
  templateUrl: './loading-indicator.component.html',
  styleUrl: './loading-indicator.component.scss'
})
export class LoadingIndicatorComponent {
  protected readonly loadingService = inject(LoadingService);
}

