using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Template.Authorization.Users;
using Template.Departments;

namespace Template.Employees
{
    public class Employee:Entity,IFullAudited,ISoftDelete
    {
        public string Name { get; set; }
        [Required]
        public Address Address { get; set; }
        
        public Department Department { get; set; }
        
        public int? DepartmentId { get; set; }

        [InverseProperty("Manager")]
        public Department ManagedDepartment { get; set; }

        [Required]
        public double Salary { get; set; }
        [Required]
        public string Title { get; set; }
        public long? CreatorUserId { get ; set; }
        public DateTime CreationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
