using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Template.Departments.DTOs
{
    public class CreateDeptDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int ManagerId { get; set; }
        public Location Location { get; set; }

    }
}
