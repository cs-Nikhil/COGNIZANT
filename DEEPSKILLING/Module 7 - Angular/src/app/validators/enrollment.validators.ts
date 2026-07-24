import { AbstractControl, AsyncValidatorFn, ValidationErrors, ValidatorFn } from '@angular/forms';
import { map, of, switchMap, timer } from 'rxjs';
import { EnrollmentService } from '../services/enrollment.service';

export function minWordCountValidator(minWords: number): ValidatorFn {
  return (control: AbstractControl<string | null>): ValidationErrors | null => {
    const value = (control.value ?? '').trim();
    if (!value) {
      return { required: true };
    }

    const words = value.split(/\s+/).filter(Boolean);
    return words.length >= minWords ? null : { minWordCount: { required: minWords, actual: words.length } };
  };
}

export function allowedCourseCodeValidator(prefixes: string[]): ValidatorFn {
  return (control: AbstractControl<string | null>): ValidationErrors | null => {
    const value = (control.value ?? '').trim().toUpperCase();
    if (!value) {
      return { required: true };
    }

    const valid = prefixes.some((prefix) => value.startsWith(prefix));
    return valid ? null : { allowedCourseCode: { prefixes } };
  };
}

export function emailTakenAsyncValidator(enrollmentService: EnrollmentService): AsyncValidatorFn {
  return (control: AbstractControl<string | null>) => {
    const email = (control.value ?? '').trim().toLowerCase();
    if (!email) {
      return of(null);
    }

    return timer(350).pipe(
      switchMap(() => enrollmentService.isEmailTaken(email)),
      map((isTaken) => (isTaken ? { emailTaken: true } : null))
    );
  };
}

