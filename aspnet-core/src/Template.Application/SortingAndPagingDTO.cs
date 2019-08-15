using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Template
{
    public enum SortDirection
    {
        asc = 0, desc = 1
    }
    public class SortingAndPagingDTO : IPagedAndSortedResultRequest
    {
        public int SkipCount { get; set ; }
        public int MaxResultCount { get ; set ; }
        public string Sorting { get ; set ; }

        public SortDirection SortingDirection { get; set; }
    }
}
