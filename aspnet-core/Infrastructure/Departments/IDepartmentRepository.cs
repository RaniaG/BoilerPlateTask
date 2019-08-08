using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Template.Departments;

namespace Infrastructure.Departments
{
    interface IDepartmentRepository: IRepository<Department>
    {
    }
}
