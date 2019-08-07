using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Template.Departments.DTOs
{
    [AutoMap(typeof(Department))]
    public class CreateDeptDTO:EntityDto<int>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int ManagerId { get; set; }

    }
}
