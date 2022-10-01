using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateChar
{
    public class Rogue : Unit
    {
        /*
            Порядок записи 
            minimum = 10,
            maximum = 45,
            physicalProtection = 0,
            healthPoint = 10,
            manaPool = 0,
            physicalAttack = 30,
            magicalAttack = 0
        */

        private static Field strengthCharacteristic = new Field(15, 55, 0, 10, 0, 20, 0);
        private static Field dexterityCharacteristic = new Field(30, 260, 15, 0, 0, 40, 0);
        private static Field constitutionCharacteristic = new Field(20, 80, 0, 60, 0, 0, 0);
        private static Field intelligenceCharacteristic = new Field(15, 70, 0, 0, 15, 0, 20);

        public static Field StrengthCharacteristic { get => strengthCharacteristic; }
        public static Field DexterityCharacteristic { get => dexterityCharacteristic; }
        public static Field ConstitutionCharacteristic { get => constitutionCharacteristic; }
        public static Field IntelligenceCharacteristic { get => intelligenceCharacteristic; }

        public Rogue(string name, int strength, int dexterity, int constitution, int intelligence, int level) :
            base(name, strength, dexterity, constitution, intelligence, level)
        {
            Max = TakeUnitStats(strength, dexterity, constitution, intelligence);
        }

        public static UnitProperty TakeUnitStats(int strength, int dexterity, int constitution, int intelligence)
        {
            var res = strengthCharacteristic.AddPoint(strength)
                + dexterityCharacteristic.AddPoint(dexterity)
                + constitutionCharacteristic.AddPoint(constitution)
                + intelligenceCharacteristic.AddPoint(intelligence);
            return res;
        }
    }
}
