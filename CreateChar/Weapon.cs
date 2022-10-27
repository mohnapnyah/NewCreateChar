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
        private int requairedInt;
        private int requairedStr;
        private int requairedDex;

        public Weapon(string itemName, int itemCount, int neededLvl, int damage, int requairedInt, int requairedStr, int requairedDex) : base(itemName, itemCount)
        {
            ItemName = itemName;
            ItemCount = itemCount;
            this.NeededLvl = neededLvl;
            this.Damage = damage;
            this.RequairedInt = requairedInt;
            this.RequairedStr = requairedStr;
            this.RequairedDex = requairedDex;
        }

        public int NeededLvl { get => neededLvl; set => neededLvl = value; }
        public int Damage { get => damage; set => damage = value; }
        public int RequairedInt { get => requairedInt; set => requairedInt = value; }
        public int RequairedStr { get => requairedStr; set => requairedStr = value; }
        public int RequairedDex { get => requairedDex; set => requairedDex = value; }
    }
}
