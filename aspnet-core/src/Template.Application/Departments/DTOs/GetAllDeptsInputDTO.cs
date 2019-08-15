using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Departments.DTOs
{
    [AutoMap(typeof(Department))]

    public class GetAllDeptsInputDTO: SortingAndPagingDTO
    {
        public string Name { get; set; }
        public int? ManagerId { get; set; }

    }
}
