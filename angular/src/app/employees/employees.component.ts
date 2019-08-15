import { Component, OnInit, Injector } from '@angular/core';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';

import { MatDialog } from '@angular/material';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  EmployeeServiceProxy, PagedResultDtoOfGetAllEmpDTO,
  GetAllEmpDTO, DepartmentServiceProxy, GetAllDeptsBriefDTO
} from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/internal/operators/finalize';
import { AddEditEmployeeComponent } from './add-edit-employee/add-edit-employee.component';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css'],
  animations: [appModuleAnimation()]
})
export class EmployeesComponent extends PagedListingComponentBase<GetAllEmpDTO>  {
  employees: GetAllEmpDTO[] = [];

  queryForm: FormGroup;
  departments: GetAllDeptsBriefDTO[];
  constructor(
    injector: Injector,
    private _empService: EmployeeServiceProxy,
    public _deptService: DepartmentServiceProxy,
    private _dialog: MatDialog,
    private fb: FormBuilder,
    private route: ActivatedRoute
  ) {
    super(injector);
    const deptId = this.route.snapshot.queryParams.departmentId ? +this.route.snapshot.queryParams.departmentId : null;
    // debugger;
    this.queryForm = this.fb.group({
      name: [''],
      departmentId: [deptId],
      sortBy: ['id'],
      sortDirection: [0]
    });
    console.log(this.queryForm);
  }
  // ngOnInit() {
  //   super.ngOnInit();
  // }

  changeItemsPerPage(items: number) {
    // debugger;
    this.pageSize = items;
    this.getDataPage(1);
  }


  protected list(request: PagedRequestDto, pageNumber: number, finishedCallback: Function): void {
    const query = this.queryForm.getRawValue();
    console.log(query);
    const deptId = query.departmentId === null ? undefined : query.departmentId; // to fix error
    this._deptService.getAllBrief()
      .subscribe((result: GetAllDeptsBriefDTO[]) => {
        this.departments = result;
      });
    this._empService.getAll(query.name, deptId, request.skipCount, request.maxResultCount, query.sortBy, query.sortDirection)
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

    createOrEditEmployeeDialog = this._dialog.open(AddEditEmployeeComponent,
      { data: { employee: emp, departments: this.departments }, disableClose: true });

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

    createOrEditEmployeeDialog = this._dialog.open(AddEditEmployeeComponent,
      { disableClose: true, data: { departments: this.departments } });

    createOrEditEmployeeDialog.afterClosed().subscribe(result => {
      if (result) {
        this.refresh();
      }
    });
  }

}
