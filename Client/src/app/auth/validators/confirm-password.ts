import { AbstractControl, AsyncValidatorFn, FormGroup } from "@angular/forms";
import { of } from "rxjs";

const passwordFieldName = "Password";

export function ConfirmPassValdiator(fg: FormGroup): AsyncValidatorFn {
	return (control: AbstractControl) => {
		return fg.controls[passwordFieldName].value !== control.value ? of({ match: { value: control.value } }) : of(null);
	};
}
