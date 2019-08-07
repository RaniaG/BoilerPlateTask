using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Template.Authorization.Users;
using Template.Departments;

namespace Template.Employees
{
    class EmpOneToOne : Entity<long>
    {
        [ForeignKey(nameof(User))]
        public override long Id { get => base.Id; set => base.Id = value; }
        public User User { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

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
    }
}
