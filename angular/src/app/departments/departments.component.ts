import { Component, OnInit, Injector } from '@angular/core';
import { GetAllDeptDTO, DepartmentServiceProxy, SortingDirection, PagedResultDtoOfGetAllDeptDTO } from '@shared/service-proxies/service-proxies';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { finalize } from 'rxjs/operators';
import { MatDialog } from '@angular/material';
import { AddEditDepartmentComponent } from './add-edit-department/add-edit-department.component';

@Component({
  selector: 'app-departments',
  templateUrl: './departments.component.html',
  styleUrls: ['./departments.component.css']
})
export class DepartmentsComponent extends PagedListingComponentBase<GetAllDeptDTO>  {

  departments: GetAllDeptDTO[];
  constructor(injector: Injector,
    private _deptService: DepartmentServiceProxy,
    private _dialog: MatDialog,
  ) {
    super(injector);
  }
  editDepartment(entity: GetAllDeptDTO) {

  }
  createDepartment() {
  }
  protected list(request: PagedRequestDto, pageNumber: number, finishedCallback: Function): void {
    this._deptService.getAll("", undefined, 0, 10, "", SortingDirection._0)
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      ).subscribe((result: PagedResultDtoOfGetAllDeptDTO) => {
        this.departments = result.items;
        this.showPaging(result, pageNumber);
      });
  }
  protected delete(entity: GetAllDeptDTO): void {
    abp.message.confirm(
      `Are you sure you want to delete ${entity.name}`,
      (result: boolean) => {
        if (result) {
          this._deptService.delete(entity.id).subscribe(() => {
            abp.notify.success('SuccessfullyDeleted');
            this.refresh();
          }, (err) => {
            abp.message.error('an error occurred try again later');
          });
        }
      }
    );
  }

}
