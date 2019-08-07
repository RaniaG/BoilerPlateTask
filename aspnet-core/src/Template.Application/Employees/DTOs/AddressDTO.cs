using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Template.Employees.DTOs
{
    [AutoMap(typeof(Address))]
    public class AddressDTO
    {
        [Required]
        public string FullAddress { get; set; }
        public int AppartmentNumber { get; set; }


    }
}
