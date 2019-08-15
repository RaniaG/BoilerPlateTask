using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Employees;

namespace Template.Departments
{
    public class DepartmentDomainService : IDepartmentDomainService
    {
        private IRepository<Employee> _empRepo { get; set; }
        private IRepository<Department> _depRepo { get; set; }
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        public DepartmentDomainService(
            IUnitOfWorkManager unitOfWorkManager
            , IRepository<Employee> empRepo,IRepository<Department> depRepo)
        {
            _empRepo = empRepo;
            _depRepo = depRepo;
            _unitOfWorkManager = unitOfWorkManager;
        }
        public void AssignManager(int DeptId, int EmpId)
        {
            Department dept = _depRepo.Get(DeptId);
            Employee emp = _empRepo.Get(EmpId);
            dept.Manager = emp;
        }
       
        public async Task DeleteDepartment(int DeptId)
        {

           
                Department dept = _depRepo.GetAllIncluding(d => d.Employees).First(d => d.Id == DeptId);
                dept.Employees.ForEach(e => e.DepartmentId = null);
                dept.ManagerId = null;
                _unitOfWorkManager.Current.SaveChanges();
                await _depRepo.DeleteAsync(DeptId);
            

        }
      

      
        public List<Employee> GetEmployees(int DeptId)
        {
            Department dept = _depRepo.GetAllIncluding(d => d.Employees)
                 .First(d => d.Id == DeptId);
           return dept.Employees;
        }

        public bool DepartmentExists(int DeptId)
        {
            return _depRepo.FirstOrDefault(DeptId)==null ? false : true;
        }
    }
}
