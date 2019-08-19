import { Injectable } from "@angular/core";
import { CanDeactivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from "@angular/router";
import { AddEditDepartmentComponent } from "./add-edit-department.component";
import { Observable } from "rxjs";


export interface CanComponentDeactivate {
    canDeactivate: () => Observable<boolean> | Promise<boolean> | boolean;
}

@Injectable()
export class CanDeactivateAddEditDepartment implements CanDeactivate<CanComponentDeactivate> {
    canDeactivate(component: AddEditDepartmentComponent, currentRoute: ActivatedRouteSnapshot,
        currentState: RouterStateSnapshot, nextState?: RouterStateSnapshot)
        : boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
        debugger;
        return component.canDeactivate ? component.canDeactivate() : true;
    }

}