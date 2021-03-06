import { NgModule, Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { AppRouteGuard } from '@shared/auth/auth-route-guard';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { UsersComponent } from './users/users.component';
import { TenantsComponent } from './tenants/tenants.component';
import { RolesComponent } from 'app/roles/roles.component';
import { ChangePasswordComponent } from './users/change-password/change-password.component';
import { EmployeesComponent } from './employees/employees.component';
import { DepartmentsComponent } from './departments/departments.component';
import { AddEditDepartmentComponent } from './departments/add-edit-department/add-edit-department.component';
import { CanDeactivateAddEditDepartment } from './departments/add-edit-department/can-deactivate-add-edit-department';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                component: AppComponent,
                children: [
                    { path: 'home', component: HomeComponent },
                    { path: 'employees', component: EmployeesComponent },
                    { path: 'departments', component: DepartmentsComponent },
                    { path: 'departments/add', component: AddEditDepartmentComponent, canDeactivate: [CanDeactivateAddEditDepartment] },
                    {
                        path: 'departments/edit/:id', component: AddEditDepartmentComponent,
                        canDeactivate: [CanDeactivateAddEditDepartment]
                    },

                    // {
                    //     path: 'departments', children: [
                    //         { path: '', component: DepartmentsComponent },
                    //         { path: 'add', component: AddEditDepartmentComponent },
                    //         { path: 'edit/:id', component: AddEditDepartmentComponent }

                    //     ]
                    // },
                    { path: 'users', component: UsersComponent },
                    // { path: 'roles', component: RolesComponent },
                    // { path: 'tenants', component: TenantsComponent },


                    // { path: 'home', component: HomeComponent,  canActivate: [AppRouteGuard] },
                    // { path: 'users', component: UsersComponent, data: { permission: 'Pages.Users' }, canActivate: [AppRouteGuard] },
                    // { path: 'roles', component: RolesComponent, data: { permission: 'Pages.Roles' }, canActivate: [AppRouteGuard] },
                    // { path: 'tenants', component: TenantsComponent, data: { permission: 'Pages.Tenants' }, canActivate: [AppRouteGuard] },
                    { path: 'about', component: AboutComponent },
                    { path: 'update-password', component: ChangePasswordComponent }
                ]
            }
        ])
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }
