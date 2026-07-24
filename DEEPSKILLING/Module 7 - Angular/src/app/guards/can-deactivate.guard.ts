import { CanDeactivateFn } from '@angular/router';
import { CanComponentDeactivate } from '../models/can-deactivate.model';

export const canDeactivateGuard: CanDeactivateFn<CanComponentDeactivate> = (component) =>
  component.canDeactivate();

