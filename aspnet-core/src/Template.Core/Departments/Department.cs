using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Template.Employees;
namespace Template.Departments
{
    public class Department:Entity<Guid>, IModificationAudited, IDeletionAudited
    {
        [Required]
        public string Name { get; set; }

        [InverseProperty("ManagedDepartment")]
        public Employee Manager { get; set; }
        [ForeignKey("Manager")]
        public long ManagerId { get; set; }

        public Location Location { get; set; }

        public List<Employee> Employees { get; set; }

        public long? LastModifierUserId { get; set ; }
        public DateTime? LastModificationTime { get; set ; }
        public bool IsDeleted { get ; set ; }
        public long? DeleterUserId { get ; set; }
        public DateTime? DeletionTime { get; set; }
    }
}
