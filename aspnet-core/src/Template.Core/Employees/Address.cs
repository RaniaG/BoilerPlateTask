using Abp.Domain.Values;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Template.Employees
{

    public class Address : ValueObject,ICloneable
    {
        
  
        private string _fullAddress;
        private int _appartmentNumber;

        public string FullAddress
        {
            get { return _fullAddress; }
        }

        public int AppartmentNumber
        {
            get { return _appartmentNumber; }
        }



        public Address()
        {

        }
        public Address(
            string FullAddress,
            int AppartmentNumber)
        {
            _fullAddress = FullAddress;
            _appartmentNumber = AppartmentNumber;
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return FullAddress;
            yield return AppartmentNumber;
        }

        public object Clone()
        {
            return new Address(FullAddress, AppartmentNumber);
        }
    }
}
