import { Component, OnInit, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { GetAllEmpsBriefDTO, EmployeeServiceProxy, DepartmentServiceProxy, GetAllDeptDTO } from '@shared/service-proxies/service-proxies';
import { TemplateValidators } from '@shared/Helpers';
import { Observable, bindCallback } from 'rxjs';
import { filter, map } from 'rxjs/operators';
import { Router, ActivatedRoute } from '@angular/router';
import { CanComponentDeactivate } from './can-deactivate-add-edit-department';

@Component({
  selector: 'app-add-edit-department',
  templateUrl: './add-edit-department.component.html',
  styleUrls: ['./add-edit-department.component.css']
})
export class AddEditDepartmentComponent extends AppComponentBase implements CanComponentDeactivate {


  deptForm: FormGroup;
  managerNameControl: FormControl;
  employees: GetAllEmpsBriefDTO[] = [];
  filteredOptions: Observable<GetAllEmpsBriefDTO[]>;
  formSaved: true;
  department: GetAllDeptDTO;
  constructor(private injector: Injector,
    private fb: FormBuilder,
    private empService: EmployeeServiceProxy,
    private deptService: DepartmentServiceProxy,
    private router: Router,
    private route: ActivatedRoute) {
    super(injector);
    this.deptForm = this.fb.group({
      name: ['', [Validators.required, TemplateValidators.isAlphabet]],
      managerId: [null, Validators.required]
    });
    this.managerNameControl = this.fb.control('', Validators.required);
    // this.empNames = this.employees.map(e => e.name);
    this.filteredOptions = this.managerNameControl.valueChanges.pipe(
      map(value => this.employees.filter(emp => emp.name.toLowerCase().includes(value.toLowerCase())))
    );
    this.empService.getAllBrief().subscribe((res: GetAllEmpsBriefDTO[]) => {
      this.employees = res;
    }, err => {
      abp.message.error("unable to perform request");
    });
  }

  ngOnInit() {
    const id = this.route.snapshot.params['id'];
    if (id) {
      this.deptService.get(id).subscribe((result: GetAllDeptDTO) => {
        this.department = result;
        this.deptForm.patchValue(this.department);
      }, err => {
        abp.message.error("Unable to perform request. Try again later");
        this.router.navigate(['app', 'departments']);
      });
    }
  }
  displayFn(emp?: GetAllEmpsBriefDTO): string | undefined {
    return emp ? emp.name : undefined;
  }
  onKeyUp() {
    // validManager=false
    debugger;

  }
  onSave() {
    if (!this.department) //create
    {
      this.deptService.create(this.deptForm.getRawValue()).subscribe(() => {
        abp.message.success("Department Created Successfully");
        this.router.navigate(['app', 'departments']);
      }, (err) => {
        abp.message.error("Unable to complete request. Try again later");
      });
    } else { //update
      this.deptService.update({ ...this.deptForm.getRawValue(), id: this.department.id })
        .subscribe(() => {
          abp.message.success("Department Updated Successfully");
          this.router.navigate(['app', 'departments']);
        }, (err) => {
          abp.message.error("Unable to complete request. Try again later");
        });
    }
  }

  optionSelected(event) {
    // debugger;
    const id = event.option.id;
    this.deptForm.get('managerId').setValue(id);
    // this.validManager = true;
  }
  canDeactivate(): Observable<boolean> {
    let result = false;
    let bindCallback(abp.message.confirm);
    // abp.message.confirm("you have unsaved changes", (res) => {
    //   result = res;
    // })
    //     return new Observable<boolean>((observer) => {
    //       const { next, error } = observer;
    //       next(result);
    //       // debugger;

    //     });

  }
}
