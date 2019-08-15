import { Component, OnInit, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-add-edit-department',
  templateUrl: './add-edit-department.component.html',
  styleUrls: ['./add-edit-department.component.css']
})
export class AddEditDepartmentComponent extends AppComponentBase {

  deptForm: FormGroup;
  dumdata: string[] = ["abc", "abcd", "abcde"];
  constructor(private injector: Injector,
    private fb: FormBuilder) {
    super(injector);
    this.deptForm = this.fb.group({
      name: [''],
      managerId: [null]
    });
  }
  // ngOnInit() {

  // }

}
