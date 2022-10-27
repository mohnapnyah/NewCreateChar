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
            this.NeededLvl = neededLvl;
            this.Armor = armor;
            this.RequairedInt = requairedInt;
            this.RequairedStr = requairedStr;
            this.RequairedDex = requairedDex;
        }

        public int NeededLvl { get => neededLvl; set => neededLvl = value; }
        public int Armor { get => armor; set => armor = value; }
        public int RequairedInt { get => requairedInt; set => requairedInt = value; }
        public int RequairedStr { get => requairedStr; set => requairedStr = value; }
        public int RequairedDex { get => requairedDex; set => requairedDex = value; }
    }
}
