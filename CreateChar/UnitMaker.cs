using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CreateChar
{
    public enum UnitsClasses
    {
        Rogue,
        Warrior,
        Wizard
    }

    public static class UnitMaker
    {
        private static readonly Dictionary<string, UnitsClasses> unitClassCode;

        public static Dictionary<string, UnitsClasses> UnitClassCode { get => unitClassCode; } 

        static UnitMaker()
        {
            unitClassCode = new Dictionary<string, UnitsClasses>()
            {
                { "Rogue",  UnitsClasses.Rogue},
                { "Warrior",  UnitsClasses.Warrior},
                { "Wizard",  UnitsClasses.Wizard},
            };
        }

        static public Unit Make(UnitsClasses pieceCode, string name, int strength, int dexterity, int constitution, int intelligence, int level)
        {
            Unit unit = null;

            switch (pieceCode)
            {
                case UnitsClasses.Rogue:
                    unit = new Rogue(name, strength, dexterity, constitution, intelligence, level);
                    break;
                case UnitsClasses.Warrior:
                    unit = new Wizard(name, strength, dexterity, constitution, intelligence, level);
                    break;
                case UnitsClasses.Wizard:
                    unit = new Wizard(name, strength, dexterity, constitution, intelligence, level);
                    break;

                default:
                    throw new Exception("Unknown unit's class");
            }

            return unit;
        }

        static public Unit Make(string unitClass, string name, int strength, int dexterity, int constitution, int intelligence, int level)
        {
            return Make(UnitClassCode[unitClass], name, strength, dexterity, constitution, intelligence, level);
        }



        static public UnitProperty TakeClassStats(UnitsClasses pieceCode, int strength, int dexterity, int constitution, int intelligence)
        {
            UnitProperty property = null;

            switch (pieceCode)
            {
                case UnitsClasses.Rogue:
                    property = Rogue.TakeUnitStats(strength, dexterity, constitution, intelligence);
                    break;
                case UnitsClasses.Warrior:
                    property = Warrior.TakeUnitStats(strength, dexterity, constitution, intelligence);
                    break;
                case UnitsClasses.Wizard:
                    property = Wizard.TakeUnitStats(strength, dexterity, constitution, intelligence);
                    break;

                default:
                    throw new Exception("Unknown unit's class");
            }

            return property;
        }

        static public UnitProperty TakeClassStats(string unitClass, int strength, int dexterity, int constitution, int intelligence)
        {
            return TakeClassStats(UnitClassCode[unitClass], strength, dexterity, constitution, intelligence);
        }



        static public Field[] GetCharacteristics(UnitsClasses pieceCode)
        {
            switch (pieceCode)
            {
                case UnitsClasses.Rogue:
                    return new Field[] 
                    { 
                        Rogue.StrengthCharacteristic, 
                        Rogue.IntelligenceCharacteristic, 
                        Rogue.ConstitutionCharacteristic,
                        Rogue.DexterityCharacteristic 
                    };
                case UnitsClasses.Warrior:
                    return new Field[] 
                    {
                        Warrior.StrengthCharacteristic,
                        Warrior.IntelligenceCharacteristic,
                        Warrior.ConstitutionCharacteristic,
                        Warrior.DexterityCharacteristic 
                    };
                case UnitsClasses.Wizard:
                    return new Field[] 
                    {
                        Wizard.StrengthCharacteristic,
                        Wizard.IntelligenceCharacteristic,
                        Wizard.ConstitutionCharacteristic,
                        Wizard.DexterityCharacteristic 
                    };

                default:
                    throw new Exception("Unknown unit's class");
            }
        }

        static public Field[] GetCharacteristics(string unitClass)
        {
            return GetCharacteristics(UnitClassCode[unitClass]);
        }


        static public Unit TransformUnit(string unitClass, Unit unit)
        {
            return Make(unitClass, unit.Name, unit.Strength, unit.Dexterity, unit.Constitution, unit.Intelligence, unit.Level);
        }
    }
}
