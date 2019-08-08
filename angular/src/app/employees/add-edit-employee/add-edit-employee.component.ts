import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { TemplateValidators } from '@shared/Helpers';

@Component({
  selector: 'app-add-edit-employee',
  templateUrl: './add-edit-employee.component.html',
  styleUrls: ['./add-edit-employee.component.css']
})
export class AddEditEmployeeComponent implements OnInit {

  employeeForm: FormGroup;
  constructor(private fb: FormBuilder) { }

  ngOnInit() {
    this.employeeForm = this.fb.group({
      name: ['', [Validators.required, Validators.maxLength(60)]],
      salary: [0, [Validators.required, TemplateValidators.isNumber]],
      title: ['', [Validators.required, Validators.maxLength(20)]],
      departmentId: [null],
      address: this.fb.group({
        fullAddress: ['', [Validators.required, Validators.maxLength(100)]],
        appartmentNumber: ['', [Validators.required, TemplateValidators.isNumber]]
      })
    });
  }

}
