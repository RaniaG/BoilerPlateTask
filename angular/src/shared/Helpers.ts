import { ValidatorFn, AbstractControl, FormControl, FormGroupDirective, NgForm } from "@angular/forms";
import { ErrorStateMatcher } from "@angular/material";

export class TemplateValidators {

  static isNumber(): ValidatorFn {
    return (control: AbstractControl): { [key: string]: any } | null => {
      return isNaN(Number(control.value)) ? { 'isNumber': { value: "value must be numbers only" } } : null;
    };
  }
  static isAlphabet(control: AbstractControl): { [key: string]: any } | null {
    return /^[a-zA-Z\s]*$/.test(control.value) ? null : { 'isAlphabet': { value: control.value } };
  }
  static isInArray(arr: string[]) {
    return (control: AbstractControl): { [key: string]: any } | null => {
      let val = control.value as string;
      return arr.find(v => v.toLowerCase() === val.toLowerCase()) ? { 'isInArray': { value: "value not in array" } } : null;
    };
  }
}

export class TemplateStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl, form: FormGroupDirective | NgForm): boolean {
    //validate the errors in case form control is touched or dirty or form is submitted
    return !!(control && control.invalid && (control.dirty || control.touched || (form && form.submitted)));
  }

}