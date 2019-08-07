using Abp.Domain.Values;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Template.Departments
{
    public class Location : ValueObject,ICloneable
    {
        [Required]
        private string _building;

        public string Building
        {
            get { return _building; }
        }

        [Required]
        private int _floor;

        public int Floor
        {
            get { return _floor; }
        }


        public Location():this("main",0)
        {

        }
        public Location(string building,int floor)
        {
            if (string.IsNullOrEmpty(building))
                throw new ArgumentNullException();
            _building = building;
            _floor = floor;
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
