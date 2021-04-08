import {FormGroup} from '@angular/forms';

// tslint:disable-next-line:typedef variable-name
export function confirmPassword(password: string, password_retype: string) {
  return (formGroup: FormGroup) => {
    const initialPassword = formGroup.controls[password];
    const matchingPassword = formGroup.controls[password_retype];
    if (matchingPassword.errors && !matchingPassword.errors.confirmedValidator) {
      return;
    }
    if (initialPassword.value !== matchingPassword.value) {
      matchingPassword.setErrors({confirmedValidator: true});
    } else {
      matchingPassword.setErrors(null);
    }
  };
}
