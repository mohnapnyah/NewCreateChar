using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CreateChar
{
    [BsonKnownTypes(typeof(Wizard), typeof(Rogue), typeof(Warrior))]
    public abstract class Unit
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        ObjectId id;

        private string name;
        private UnitProperty max;
        private int strength;
        private int dexterity;
        private int constitution;
        private int intelligence;
        private int experience = 0;
        private int level = 1;
        private string perk;
        Helmet helmet;
        Chestplate chestplate;
        Weapon weapon;

        [BsonIgnoreIfNull]
        public List<Item> Items { get; set; }
        public string Name { get => name; set => name = value; }
        public UnitProperty Max { get => max; set => max = value; }
        public int Strength { get => strength; set => strength = value; }
        public int Dexterity { get => dexterity; set => dexterity = value; }
        public int Constitution { get => constitution; set => constitution = value; }
        public int Intelligence { get => intelligence; set => intelligence = value; }
        public int Experience { get => experience; set => experience = value; }
        public int Level { get => level; set => level = value; }
        public string Perk { get => perk; set => perk = value; }

        protected Unit(string name, int strength, int dexterity, int constitution, int intelligence, int level)
        {
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intelligence = intelligence;
            Name = name;
            Level = level;
            Items = new List<Item>();
        }

        public override string ToString()
        {
            return $"{Name}\n\n{Max}";
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        public void Removeitem(Item item)
        {
            Items.Remove(item);
        }
    }
}