using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CreateChar;

namespace CreateCharWpf
{
    /// <summary>
    /// Логика взаимодействия для Inventory.xaml
    /// </summary>
    public partial class Inventory : Window
    {
        Unit unit;
        string selected;
        public Inventory(List<Item> equipment, Unit i, string selected)
        {
            InitializeComponent();
            foreach(var a in equipment)
            {
                Shop.Items.Add(a);
            }
            Unit = i;
            selected = selected;
        }

        public Unit Unit { get => unit; set => unit = value; }

        private void Shop_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Item item = (sender as ListView).SelectedItem as Item;
            unit = Unit;
            if (item is Helmet)
            {
                var a = item as Helmet;
                if (Unit.Strength >= a.RequairedStr &&
                    Unit.Intelligence >= a.RequairedInt &&
                    Unit.Dexterity >= a.RequairedDex &&
                    Unit.Level >= a.NeededLvl)
            {
                    Unit.Helmet = a;
                    Helmet.Text = a.ItemName;
                    MongoExample.ReplaceUnit($"{selected}", (Unit)unit);
                }
            else { MessageBox.Show("Недостаточно статиков на этот шлем"); }
            }
            if(item is Chestplate)
            {
                var a = item as Chestplate;
                if (Unit.Strength >= a.RequairedStr &&
                    Unit.Intelligence >= a.RequairedInt &&
                    Unit.Dexterity >= a.RequairedDex &&
                    Unit.Level >= a.NeededLvl)
                {
                    Unit.Chestplate = a;
                    Chestplate.Text = a.ItemName;
                    MongoExample.ReplaceUnit($"{selected}", (Unit)unit);
                }
                else { MessageBox.Show("Недостаточно статиков на этот честплейт"); }
            }
            if (item is Weapon)
            {
                var a = item as Weapon;
                if (Unit.Strength >= a.RequairedStr &&
                    Unit.Intelligence >= a.RequairedInt &&
                    Unit.Dexterity >= a.RequairedDex &&
                    Unit.Level >= a.NeededLvl)
                {
                    Unit.Weapon = a;
                    Weapon.Text = a.ItemName;
                    MongoExample.ReplaceUnit($"{selected}", (Unit)unit);
                }
                else { MessageBox.Show("Недостаточно статиков на этот виапон"); }
            }
        }
    }
}
