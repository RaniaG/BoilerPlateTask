using Abp.Application.Services;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Template.Departments.DTOs;

namespace Template.Departments
{
    public class DepartmentAppService : AsyncCrudAppService<Department, GetAllDeptDTO,int,GetAllDeptsInputDTO,CreateDeptDTO>
    {
        public DepartmentAppService(IRepository<Department, int> repository) : base(repository)
        {
        }
    }
}
