using Abp.Domain.Values;
using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Departments
{
    public class Location : ValueObject,ICloneable
    {
        public string Building { get;}
        public int Floor { get; }

        public Location(string building,int floor)
        {
            Building = building;
            Floor = floor;
        }
        public object Clone()
        {
            return new Location(Building, Floor);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Building;
            yield return Floor;
        }
    }
}
