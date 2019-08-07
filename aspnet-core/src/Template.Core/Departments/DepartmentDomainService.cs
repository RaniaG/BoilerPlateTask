using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Template.Employees;

namespace Template.Departments
{
    public class DepartmentDomainService : IDepartmentDomainService
    {
        private IRepository<Employee> _empRepo { get; set; }
        private IRepository<Department> _depRepo { get; set; }

        public DepartmentDomainService(IRepository<Employee> empRepo,IRepository<Department> depRepo)
        {
            _empRepo = empRepo;
            _depRepo = depRepo;
        }
        public void AssignManager(int DeptId, int EmpId)
        {
            Department dept = _depRepo.Get(DeptId);
            Employee emp = _empRepo.Get(EmpId);
            dept.Manager = emp;
        }

        public void DeleteDepartment(int DeptId)
        {
            Department dept = _depRepo.Get(DeptId);
            dept.Employees.ForEach(e => e.Department = null);
            _depRepo.Delete(DeptId);
        }

        public List<Employee> GetEmployees(int DeptId)
        {
            Department dept = _depRepo.GetAllIncluding(d => d.Employees)
                 .First(d => d.Id == DeptId);
           return dept.Employees;
        }
    }
}
