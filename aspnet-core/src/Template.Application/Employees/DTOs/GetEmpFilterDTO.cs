﻿using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Employees.DTOs
{
    public class GetEmpFilterDTO: IPagedAndSortedResultRequest
    {
        public int SkipCount { get; set; }
        public int MaxResultCount { get; set; }
        public string Sorting { get; set; }
    }
}
