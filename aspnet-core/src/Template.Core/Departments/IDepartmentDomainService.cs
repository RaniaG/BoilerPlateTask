using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Template.Employees;

namespace Template.Departments
{
    interface IDepartmentDomainService: IDomainService
    {
        List<Employee> GetEmployees(int DeptId);

        void DeleteDepartment(int DeptId);

        void AssignManager(int DeptId, int EmpId);

    }
}
