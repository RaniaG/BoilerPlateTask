using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Template.Authorization.Users;
using Template.Departments;

namespace Template.Employees
{
    public class Employee:User
    {
        [Required]
        public Address Address { get; set; }

        
        public Department Department { get; set; }
        
        public Guid DepartmentId { get; set; }

        [Required]
        public Double Salary { get; set; }
        [Required]
        public string Title { get; set; }
    }
}
