using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateChar
{
    public class Weapon : Item
    {
        int neededLvl;
        int damage;

        public Weapon(string itemName, int itemCount, int neededLvl, int damage) : base(itemName, itemCount)
        {
            ItemName = itemName;
            ItemCount = itemCount;
            this.neededLvl = neededLvl;
            this.damage = damage;
        }
    }
}
