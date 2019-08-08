using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Employees
{
    class EmployeeDomainService : IEmployeeDomainService
    {
        private readonly IRepository<Employee> _empRepository;
        public EmployeeDomainService(IRepository<Employee> Repository)
        {
            _empRepository = Repository;
        }
        public bool EmployeeExists(int EmpId)
        {
            return _empRepository.FirstOrDefault(EmpId) == null ? false : true;
        }
    }
}
