using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Template.Employees.DTOs
{
    [AutoMap(typeof(Employee))]

    public class CreateEmpDTO:EntityDto<int>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Address Address { get; set; }
        [Required]
        public double Salary { get; set; }
        [Required]
        public string Title { get; set; }
        public int? DepartmentId { get; set; }
    }
}
