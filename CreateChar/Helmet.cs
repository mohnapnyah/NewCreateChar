using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateChar
{
    public class Helmet : Item
    {
        private int neededLvl;
        private int armor;
        private int requairedInt;
        private int requairedStr;
        private int requairedDex;
        public Helmet(string itemName, int itemCount, int neededLvl, int armor, int requairedInt, int requairedStr, int requairedDex) : base(itemName, itemCount)
        {
            ItemName = itemName;
            ItemCount = itemCount;
            this.neededLvl = neededLvl;
            this.armor = armor;
            this.requairedInt = requairedInt;
            this.requairedStr = requairedStr;
            this.requairedDex = requairedDex;
        }
    }
}
