using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Employees
{
    public interface IEmployeeDomainService : IDomainService
    {
        bool EmployeeExists(int EmpId);
    }
}
