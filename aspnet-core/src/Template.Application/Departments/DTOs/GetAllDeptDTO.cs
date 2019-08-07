using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Template.Employees;

namespace Template.Departments.DTOs
{
    [AutoMap(typeof(Department))]
    public class GetAllDeptDTO: EntityDto<int>
    {
        public string Name { get; set; }
        public Employee Manager { get; set; }

    }
}
