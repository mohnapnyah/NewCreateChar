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
        public Inventory(List<Item> equipment, Unit i)
        {
            InitializeComponent();
            foreach(var a in equipment)
            {
                Shop.Items.Add(a);
            }
            unit = i;
        }

        private void Shop_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Item item = (sender as ListView).SelectedItem as Item;
            if (item is Helmet)
            {
                var i = item as Helmet;
                if (unit.Strength >= i.RequairedStr &&
                    unit.Intelligence >= i.RequairedInt &&
                    unit.Dexterity >= i.RequairedDex &&
                    unit.Level >= i.NeededLvl)
            {
                    unit.Helmet = i;
                    Helmet.Text = i.ItemName;
            }
            else { MessageBox.Show("Недостаточно статиков на этот шлем"); }
            }
            if(item is Chestplate)
            {
                var i = item as Chestplate;
                if (unit.Strength >= i.RequairedStr &&
                    unit.Intelligence >= i.RequairedInt &&
                    unit.Dexterity >= i.RequairedDex &&
                    unit.Level >= i.NeededLvl)
                {
                    unit.Chestplate = i;
                    Chestplate.Text = i.ItemName;
                }
                else { MessageBox.Show("Недостаточно статиков на этот честплейт"); }
            }
            if (item is Weapon)
            {
                var i = item as Weapon;
                if (unit.Strength >= i.RequairedStr &&
                    unit.Intelligence >= i.RequairedInt &&
                    unit.Dexterity >= i.RequairedDex &&
                    unit.Level >= i.NeededLvl)
                {
                    unit.Weapon = i;
                    Weapon.Text = i.ItemName;
                }
                else { MessageBox.Show("Недостаточно статиков на этот виапон"); }
            }
        }
    }
}
