using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateChar
{
    internal class Helmet : Item
    {
        private int neededLvl;
        private int armor;

        public Helmet(string itemName, int itemCount, int neededLvl, int damage) : base(itemName, itemCount)
        {
            ItemName = itemName;
            ItemCount = itemCount;
            this.neededLvl = neededLvl;
            this.armor = damage;
        }
    }
}
