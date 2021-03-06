import { Component, Injector, ViewEncapsulation } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { MenuItem } from '@shared/layout/menu-item';

@Component({
    templateUrl: './sidebar-nav.component.html',
    selector: 'sidebar-nav',
    encapsulation: ViewEncapsulation.None
})
export class SideBarNavComponent extends AppComponentBase {

    menuItems: MenuItem[] = [
        new MenuItem(this.l('HomePage'), '', 'home', '/app/home'),

        new MenuItem(this.l('Departments'), 'Pages.Departments', 'business', '/app/departments'),
        new MenuItem(this.l('Employees'), 'Pages.Employees', 'people', '/app/employees'),
        new MenuItem(this.l('Users'), 'Pages.Users', 'people', '/app/users'),

        // new MenuItem(this.l('Roles'), 'Pages.Roles', 'local_offer', '/app/roles'),
        // new MenuItem(this.l('About'), '', 'info', '/app/about'),


    ];

    constructor(
        injector: Injector
    ) {
        super(injector);
    }

    showMenuItem(menuItem): boolean {
        // if (menuItem.permissionName) {
        //     return this.permission.isGranted(menuItem.permissionName);
        // }

        return true;
    }
}
