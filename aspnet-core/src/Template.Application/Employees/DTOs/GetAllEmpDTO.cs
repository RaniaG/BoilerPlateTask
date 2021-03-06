﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Template.Departments;
using Template.Departments.DTOs;

namespace Template.Employees.DTOs
{
    [AutoMap(typeof(Employee))]
    public class GetAllEmpDTO:EntityDto<int>
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public GetAllDeptsBriefDTO Department { get; set; }
        public int? DepartmentId { get; set; }
        public double Salary { get; set; }
        public string Title { get; set; }

    }

}
