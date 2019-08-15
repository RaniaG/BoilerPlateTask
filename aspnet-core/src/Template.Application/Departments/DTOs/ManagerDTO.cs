using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Template.Employees;

namespace Template.Departments.DTOs
{
    [AutoMap(typeof(Employee))]
    public class ManagerDTO:EntityDto
    {
        public string Name { get; set; }
    }
}
