import { Component, OnInit, Injector, Inject } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { TemplateValidators, TemplateStateMatcher } from '@shared/Helpers';
import { AppComponentBase } from '@shared/app-component-base';
import { EmployeeServiceProxy, DepartmentServiceProxy, PagedResultDtoOfGetAllDeptDTO, GetAllDeptDTO, CreateEmpDTO, GetAllDeptsBriefDTO } from '@shared/service-proxies/service-proxies';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-add-edit-employee',
  templateUrl: './add-edit-employee.component.html',
  styleUrls: ['./add-edit-employee.component.css']
})
export class AddEditEmployeeComponent extends AppComponentBase implements OnInit {

  employeeForm: FormGroup;
  departments: GetAllDeptsBriefDTO[];
  empDto: CreateEmpDTO;
  saved: boolean;
  constructor(
    injector: Injector,
    public empService: EmployeeServiceProxy,
    public deptService: DepartmentServiceProxy,
    private fb: FormBuilder,
    private _dialogRef: MatDialogRef<AddEditEmployeeComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
    super(injector);
  }
  //or provide it globally
  matcher = new TemplateStateMatcher();
  ngOnInit() {
    this.employeeForm = this.fb.group({
      name: ['', [Validators.required, Validators.maxLength(60), TemplateValidators.isAlphabet]],
      salary: [null, [Validators.required, TemplateValidators.isNumber()]],
      title: ['', [Validators.required, Validators.maxLength(20), TemplateValidators.isAlphabet]],
      departmentId: [null],
      address: this.fb.group({
        fullAddress: ['', Validators.required],
        appartmentNumber: [null, [Validators.required, TemplateValidators.isNumber()]]
      })
    });
    // this.getAllDepartments();
    // debugger;
    this.departments = this.data.departments;

    this.saved = true;
    if (this.data.employee) {
      this.employeeForm.patchValue(this.data.employee);
    }
  }
  getAllDepartments() {
    this.deptService.getAllBrief()
      .subscribe((result: GetAllDeptsBriefDTO[]) => {
        // debugger;
        this.departments = result;
      });
  }
  create() {
    // debugger;
    this.empService.create(this.employeeForm.getRawValue())
      .subscribe((res) => {
        this._dialogRef.close(true);
      }, (err) => {
        abp.message.error('Unable to complete request try again later');
        this._dialogRef.close(false);
      });
  }
  update() {
    const empToUpdate = { ...this.employeeForm.getRawValue(), id: this.data.employee.id };
    this.empService.update(empToUpdate)
      .subscribe((res) => {
        this._dialogRef.close(true);
      }, (err) => {
        abp.message.error('Unable to complete request try again later');
        this._dialogRef.close(false);
      });
  }
  myCancel() {
    if (!this.saved) {
      // debugger;
      const dialogRef = this._dialogRef;
      abp.message.confirm('Are you sure you want to save', (res) => {
        if (res) {
          dialogRef.close(false);
        }
      });
    } else {
      this._dialogRef.close(false);
    }
  }

}
