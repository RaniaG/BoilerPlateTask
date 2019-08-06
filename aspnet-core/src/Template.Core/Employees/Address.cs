using Abp.Domain.Values;
using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Employees
{
    public class Address : ValueObject,ICloneable
    {

        public string FullAddress { get; }

        public int Number { get; }
        

        public Address(
            string FullAddress,
            int number)
        {
            this.FullAddress = FullAddress;
            Number = number;
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return FullAddress;
            yield return Number;
        }

        public object Clone()
        {
            return new Address(FullAddress, Number);
        }
    }
}
