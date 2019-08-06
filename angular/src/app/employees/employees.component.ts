import { Component, OnInit, Injector } from '@angular/core';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { EmployeeDTO } from './employeeDto';
import { EmployeeService } from './employee.service';
import { MatDialog } from '@angular/material';
import { appModuleAnimation } from '@shared/animations/routerTransition';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css'],
  animations: [appModuleAnimation()]
})
export class EmployeesComponent extends PagedListingComponentBase<EmployeeDTO> {
  users: EmployeeDTO[] = [];
  keyword = '';
  isActive: boolean | null;

  constructor(
    injector: Injector,
    private _empService: EmployeeService,
    private _dialog: MatDialog
  ) {
    super(injector);
  }
  protected list(request: PagedRequestDto, pageNumber: number, finishedCallback: Function): void {
    throw new Error("Method not implemented.");
  }


  protected delete(entity: EmployeeDTO): void {
    throw new Error("Method not implemented.");
  }


}
