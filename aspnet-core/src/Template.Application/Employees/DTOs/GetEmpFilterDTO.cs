using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Employees.DTOs
{
   
    [AutoMap(typeof(Employee))]
    public class GetEmpFilterDTO: SortingAndPagingDTO
    {
        public string Name { get; set; }
        public int? DepartmentId { get; set; }
        
    }
}
