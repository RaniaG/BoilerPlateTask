using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Departments.DTOs
{
    [AutoMap(typeof(Department) )]
    public class GetAllDeptsBriefDTO:EntityDto
    {
        public string Name { get; set; }
    }
}
