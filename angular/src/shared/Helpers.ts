import { ValidatorFn, AbstractControl } from "@angular/forms";

export class TemplateValidators {

    static isNumber(): ValidatorFn {
        return (control: AbstractControl): {[key: string]: any} | null => {
          return /^\d+\.\d+$/.test(control.value) ? {'value must be a number': {value: control.value}} : null;
        };
      }
}