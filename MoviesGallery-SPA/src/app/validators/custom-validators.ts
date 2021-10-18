import { AbstractControl, AsyncValidatorFn, ValidationErrors } from "@angular/forms";
import { Observable } from "rxjs";

let emailList = [
    "test@gmail.com",
    "test2@gmail.com"
];

export class CustomValidators {
    static asyncBlockedEmail(): AsyncValidatorFn {
        return (control: AbstractControl): Observable<ValidationErrors | null> | Promise<ValidationErrors | null> => {
            const promise = new Promise<ValidationErrors | null>((resolve, reject) => {
                setTimeout(() => {
                    if(emailList.includes(control.value)) {
                        resolve({'blockedEmail': true});
                    } else {
                        resolve(null);
                    }
                }, 1500);
            });

            return promise;
        }
    }
}