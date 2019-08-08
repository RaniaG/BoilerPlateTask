using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Employees;

namespace Template.Departments
{
    public interface IDepartmentDomainService: IDomainService
    {
        List<Employee> GetEmployees(int DeptId);

        Task DeleteDepartment(int DeptId);

        void AssignManager(int DeptId, int EmpId);

        bool DepartmentExists(int DeptId);
    }
}
