using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateChar
{
    public class Field
    {
        public Field(int minimum, int maximum, UnitProperty property)
        {
            Minimum = minimum;
            Maximum = maximum;
            Property = property;
        }

        public Field(int minimum, int maximum, int physicalProtection, int healthPoint, 
            int manaPool, int physicalAttack, int magicalAttack)
        {
            Minimum = minimum;
            Maximum = maximum;
            Property = new UnitProperty(physicalProtection, healthPoint, manaPool, physicalAttack, magicalAttack);
        }

        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public UnitProperty Property { get; set; }

        public UnitProperty AddPoint(int points)
        {
            return Property * points;
        }
    }
}
