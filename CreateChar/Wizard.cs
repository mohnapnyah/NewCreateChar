﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateChar
{
    public class Wizard : Unit
    {
        /*
         * Порядок записи 
            minimum = 10,
            maximum = 45,
            physicalProtection = 0,
            healthPoint = 10,
            manaPool = 0,
            physicalAttack = 30,
            magicalAttack = 0
        */

        static Field strengthCharacteristic = new Field(10, 45, 0, 10, 0, 30, 0);
        static Field dexterityCharacteristic = new Field(20, 70, 5, 0, 0, 0, 0);
        static Field constitutionCharacteristic = new Field(15, 60, 10, 30, 0, 0, 0);
        static Field intelligenceCharacteristic = new Field(35, 250, 0, 0, 20, 0, 50);

        public static Field StrengthCharacteristic { get => strengthCharacteristic; }
        public static Field DexterityCharacteristic { get => dexterityCharacteristic; }
        public static Field ConstitutionCharacteristic { get => constitutionCharacteristic; }
        public static Field IntelligenceCharacteristic { get => intelligenceCharacteristic; }

        public Wizard(string name, int strength, int dexterity, int constitution, int intelligence) :
            base(name, strength, dexterity, constitution, intelligence)
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