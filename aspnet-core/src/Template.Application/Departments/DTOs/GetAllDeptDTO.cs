using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using Template.Employees;

namespace Template.Departments.DTOs
{
    public class GetAllDeptDTO:EntityDto<int>
    {
        public string Name { get; set; }
        public Employee Manager { get; set; }
        public Location Location { get; set; }

    }
}
