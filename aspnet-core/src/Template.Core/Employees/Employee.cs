﻿using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Template.Authorization.Users;
using Template.Departments;

namespace Template.Employees
{
    public class Employee:Entity<Guid>
    {
        [Required]
        public Address Address { get; set; }
        
        public Department Department { get; set; }
        
        public Guid? DepartmentId { get; set; }

        [InverseProperty("Manager")]
        public Department ManagedDepartment { get; set; }

        [Required]
        public Double Salary { get; set; }
        [Required]
        public string Title { get; set; }

        public Employee()
        {

        }

    }
}
