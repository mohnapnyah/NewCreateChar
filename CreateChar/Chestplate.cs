using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateChar
{
    public class Chestplate : Item
    {
        private int neededLvl;
        private int armor;

        public Chestplate(string itemName, int itemCount, int neededLvl, int damage) : base(itemName, itemCount)
        {
            ItemName = itemName;
            ItemCount = itemCount;
            this.neededLvl = neededLvl;
            this.armor = damage;
        }
    }
}
