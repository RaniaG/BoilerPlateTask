using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Employees.DTOs
{
    [AutoMap(typeof(Employee))]
    public class PatchEmpDTO
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Title { get; set; }
    }
}
