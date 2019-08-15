import { Component, OnInit, Injector } from '@angular/core';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';

import { MatDialog } from '@angular/material';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { EmployeeServiceProxy, PagedResultDtoOfGetAllEmpDTO, GetAllEmpDTO } from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/internal/operators/finalize';
import { AddEditEmployeeComponent } from './add-edit-employee/add-edit-employee.component';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css'],
  animations: [appModuleAnimation()]
})
export class EmployeesComponent extends PagedListingComponentBase<GetAllEmpDTO> {
  employees: GetAllEmpDTO[] = [];
  keyword = '';
  department: number;
  queryForm: FormGroup;
  constructor(
    injector: Injector,
    private _empService: EmployeeServiceProxy,
    private _dialog: MatDialog,
    private fb: FormBuilder
  ) {
    super(injector);
    this.queryForm = this.fb.group({
      name: [''],
      departmentId: [null],
      sortBy: ['']
    });
  }
  changeItemsPerPage(items: number) {
    // debugger;
    this.pageSize = items;
    this.getDataPage(1);
  }


  protected list(request: PagedRequestDto, pageNumber: number, finishedCallback: Function): void {
    const query = this.queryForm.getRawValue();
    console.log(query);
    this._empService.getAll(query.name, query.departmentId, request.skipCount, request.maxResultCount, query.sortBy)
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: PagedResultDtoOfGetAllEmpDTO) => {
        this.employees = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  protected editEmployee(emp: GetAllEmpDTO): void {
    let createOrEditEmployeeDialog;

    createOrEditEmployeeDialog = this._dialog.open(AddEditEmployeeComponent, { data: emp, disableClose: true });

    createOrEditEmployeeDialog.afterClosed().subscribe(result => {
      if (result) {
        this.refresh();
      }
    });
  }
  protected createEmployee(): void {

  }
  protected assignEmployeeToDept(employee: GetAllEmpDTO): void {

  }
  protected delete(entity: GetAllEmpDTO): void {
    abp.message.confirm(
      `Are you sure you want to delete ${entity.name}`,
      (result: boolean) => {
        if (result) {
          this._empService.delete(entity.id).subscribe(() => {
            abp.notify.success('SuccessfullyDeleted');
            this.refresh();
          });
        }
      }
    );
  }
  private showCreateUserDialog(): void {
    let createOrEditEmployeeDialog;

    createOrEditEmployeeDialog = this._dialog.open(AddEditEmployeeComponent, { disableClose: true });

    createOrEditEmployeeDialog.afterClosed().subscribe(result => {
      if (result) {
        this.refresh();
      }
    });
  }

}
