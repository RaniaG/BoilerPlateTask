using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Employees.DTOs
{
    public enum SortDirection
    {
        asc=0,desc=1
    }
    [AutoMap(typeof(Employee))]
    public class GetEmpFilterDTO: IPagedAndSortedResultRequest
    {
        public string Name { get; set; }
        public int? DepartmentId { get; set; }
        public int SkipCount { get; set; }
        public int MaxResultCount { get; set; }
        public string Sorting { get; set; }
        public SortDirection SortingDirection { get; set; }
    }
}
