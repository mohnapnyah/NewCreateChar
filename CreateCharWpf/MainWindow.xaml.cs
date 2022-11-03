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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CreateChar;
using MongoDB.Driver;
using MongoDB;
using System.Collections;
using System.Xml.Linq;
using System.Security.Policy;

namespace CreateCharWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Field StrengthCharacteristic;
        Field DexterityCharacteristic;
        Field ConstitutionCharacteristic;
        Field IntelligenceCharacteristic;
        int MarginTopItem;
        List<Item> items;
        List<Item> equipment;

        Helmet baseMageHelmet = new Helmet("bomjeMageHelmet", 1, 1, 1, 20, 5, 0);
        Helmet mediumMageHelmet = new Helmet("normMageHelmet", 1, 5, 5, 40, 10, 5 );
        Helmet coolMageHelmet = new Helmet("krutoyMageHelmet", 1, 10, 10, 70, 20, 10);

        Helmet baseWarHelmet = new Helmet("bomjeWarHelmet", 1, 1, 10, 0, 15, 5);
        Helmet mediumWarHelmet = new Helmet("normWarHelmet", 1, 5, 20, 5, 40, 15);
        Helmet coolWarHelmet = new Helmet("krutoyWarHelmet", 1, 10, 40, 10, 60, 20);

        Helmet baseRogHelmet = new Helmet("bomjeRogHelmet", 1, 1, 1, 0, 5, 15);
        Helmet mediumRogHelmet = new Helmet("normRogHelmet", 1, 5, 5, 1, 10, 40);
        Helmet coolRogHelmet = new Helmet("krutoyWHelmet", 1, 5, 10, 10, 15, 45);

        Chestplate baseMageChestplate = new Chestplate("bomjeMageChestplate", 1, 1, 10, 25, 5, 0);
        Chestplate mediumMageChestplate = new Chestplate("normMageChestplate", 1, 3, 25, 45, 10, 5);
        Chestplate coolMageChestplate = new Chestplate("krutoyMageChestplate", 1, 8, 35, 75, 20, 10);

        Chestplate baseWarChestplate = new Chestplate("bomjeWarChestplate", 1, 1, 20, 5, 20, 10);
        Chestplate mediumWarChestplate = new Chestplate("normWarChestplate", 1, 3, 40, 10, 50, 25);
        Chestplate coolWarChestplate = new Chestplate("krutoyWarChestplate", 1, 8, 80, 15, 70, 30);

        Chestplate baseRogChestplate = new Chestplate("bomjeRogChestplate", 1, 1, 5, 0, 20, 10);
        Chestplate mediumRogChestplate = new Chestplate("normRogChestplate", 1, 3, 15, 15, 25, 25);
        Chestplate coolRogChestplate = new Chestplate("krutoyWarChestplate", 1, 8, 30, 20, 30, 60);

        Weapon littleWand = new Weapon("littleWand", 1, 1, 5, 25, 5, 0);
        Weapon mediumWand = new Weapon("normMmediumWandageChestplate", 1, 10, 20, 45, 10, 5);
        Weapon BFG = new Weapon("BFG", 1, 20, 100, 75, 20, 10);

        Weapon baseDubina = new Weapon("baseDubina", 1, 1, 15, 5, 20, 10);
        Weapon betterDubina = new Weapon("betterDubina", 1, 10, 40, 10, 50, 25);
        Weapon greatDubinaOfDubina = new Weapon("greatDubinaOfDubina", 1, 15, 80, 15, 70, 30);

        Weapon tinyZatochka = new Weapon("tinyZatochka", 1, 1, 5, 0, 20, 10);
        Weapon meduimZatochka = new Weapon("meduimZatochka", 1, 10, 50, 15, 25, 25);
        Weapon bestZatochka = new Weapon("bestZatochka", 1, 15, 30, 75, 30, 60);

        public MainWindow()
        {
            InitializeComponent();
            items = new List<Item>();
            equipment = new List<Item>();
            ChangeClassComboBox.Items.Clear();
            
            foreach (var i in UnitMaker.UnitClassCode)
            {
                ChangeClassComboBox.Items.Add(i.Key);
            }
            ChangeClassComboBox.SelectedIndex = 0;
            ChangeClass($"{ChangeClassComboBox.SelectedValue}");
            TextInfoUpdate();
            ShowFinalStats();
            ChangeUnitComboBoxUpdate();
            equipment.Add(baseMageHelmet);
            equipment.Add(mediumMageHelmet);
            equipment.Add(coolMageHelmet);

            equipment.Add(baseWarHelmet);
            equipment.Add(mediumWarHelmet);
            equipment.Add(coolWarHelmet);

            equipment.Add(baseRogHelmet);
            equipment.Add(mediumRogHelmet);
            equipment.Add(coolRogHelmet);

            equipment.Add(baseRogHelmet);
            equipment.Add(mediumRogHelmet);
            equipment.Add(coolRogHelmet);

            equipment.Add(baseMageChestplate);
            equipment.Add(mediumMageChestplate);
            equipment.Add(coolMageChestplate);

            equipment.Add(baseWarChestplate);
            equipment.Add(mediumWarChestplate);
            equipment.Add(coolWarChestplate);

            equipment.Add(baseRogChestplate);
            equipment.Add(mediumRogChestplate);
            equipment.Add(coolRogChestplate);

            equipment.Add(littleWand);
            equipment.Add(mediumWand);
            equipment.Add(BFG);

            equipment.Add(baseDubina);
            equipment.Add(betterDubina);
            equipment.Add(greatDubinaOfDubina);

            equipment.Add(tinyZatochka);
            equipment.Add(meduimZatochka);
            equipment.Add(bestZatochka);
        }

        private void ChangeClass(string currentClass)
        {
            Field[] characteristics = UnitMaker.GetCharacteristics($"{ChangeClassComboBox.SelectedValue}");
            StrengthCharacteristic = characteristics[0];
            IntelligenceCharacteristic = characteristics[1];
            ConstitutionCharacteristic = characteristics[2];
            DexterityCharacteristic = characteristics[3];

            SliderStrength.Maximum = StrengthCharacteristic.Maximum;
            SliderStrength.Minimum = StrengthCharacteristic.Minimum;

            SliderIntellingence.Maximum = IntelligenceCharacteristic.Maximum;
            SliderIntellingence.Minimum = IntelligenceCharacteristic.Minimum;

            SliderConstitution.Maximum = ConstitutionCharacteristic.Maximum;
            SliderConstitution.Minimum = ConstitutionCharacteristic.Minimum;

            SliderDexterity.Maximum = DexterityCharacteristic.Maximum;
            SliderDexterity.Minimum = DexterityCharacteristic.Minimum;
        }

        private void SliderStrength_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TextInfoUpdate();
            ShowFinalStats();
        }

        private void TextInfoUpdate()
        {
            TextStrength.Text = (int)SliderStrength.Value + "";
            TextIntellingence.Text = (int)SliderIntellingence.Value + "";
            TextConstitution.Text = (int)SliderConstitution.Value + "";
            TextDexterity.Text = (int)SliderDexterity.Value + "";
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (InsertName.Text != "")
            {
                var newUnit = UnitMaker.Make(
                            $"{ChangeClassComboBox.SelectedValue}",
                            InsertName.Text,
                            (int)SliderStrength.Value,
                            (int)SliderDexterity.Value,
                            (int)SliderConstitution.Value,
                            (int)SliderIntellingence.Value,
                            int.Parse(lvlBox.Text));
                newUnit.Perk = perks.Text;
                foreach (var i in Inventory.Children)
                {
                    var j = i as CheckBox;
                    foreach (var item in items)
                    {
                        if (j.IsChecked == true)
                        {
                            if ($"{j.Content}" == item.ItemName)
                            {
                                newUnit.AddItem(item);
                            }
                        }
                    }
                }
                if (MongoExample.Find(newUnit.Name) == null)
                {
                    MongoExample.AddToDB(newUnit);
                    ChangeUnitComboBoxUpdate();
                }
                else
                {
                    if (MessageBox.Show("You want overwrite this unit?",
                    "Overwrite unit",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        MongoExample.ReplaceUnit(newUnit.Name, newUnit);
                    }
                }
            }
            
        }

        private void ShowFinalStats()
        {
            UnitProperty res = UnitMaker.TakeClassStats(
                            $"{ChangeClassComboBox.SelectedValue}",
                            (int)SliderStrength.Value,
                            (int)SliderDexterity.Value,
                            (int)SliderConstitution.Value,
                            (int)SliderIntellingence.Value);
            FinalStatsText.Text = res.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateItemWindow createItemWindow = new CreateItemWindow();
            if (createItemWindow.ShowDialog() == true)
            {
                var item = new Item(createItemWindow.ItemName.Text, Convert.ToInt32(createItemWindow.ItemCount.Text));
                foreach (var i in items)
                {
                    if (i.ItemName == item.ItemName)
                    {
                        return;
                    }
                }
                items.Add(item);
                Inventory.Children.Add(new CheckBox { Content = $"{item.ItemName}", Margin = new Thickness(10, MarginTopItem, 0, 0) });
                MarginTopItem += 20;
            }
        }

        private void ChangeUnitComboBoxUpdate()
        {
            var users = MongoExample.FindAll();
            ChangeUnit.Items.Clear();
            foreach (var i in users)
            {
                ChangeUnit.Items.Add(i.Name);
            }
        }

        private void ChangeUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var i = MongoExample.Find($"{ChangeUnit.SelectedValue}");
            ChangeClass(i.GetType().Name);
            InsertName.Text = i.Name;
            ChangeClassComboBox.SelectedValue = i.GetType().Name;
            SliderStrength.Value = i.Strength;
            SliderIntellingence.Value = i.Intelligence;
            SliderDexterity.Value = i.Dexterity;
            SliderConstitution.Value = i.Constitution;
            //perks.Text = i.Perk;
            lvlBox.Text = i.Level.ToString();
            exp.Value = i.Experience;
            exp.Maximum = i.Level * 3000;
            

            if (i.Items != null)
            {
                foreach (var unitItem in i.Items)
                {
                    if (items.Count == 0)
                    {
                        items.Add(unitItem);
                    }
                    else
                    {
                        try
                        {
                            foreach (var item in items)
                            {
                                if (unitItem.ItemName != item.ItemName)
                                {
                                    items.Add(unitItem);
                                }
                            }
                        }
                        catch (InvalidOperationException invalidOperationException) { }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }

            Inventory.Children.Clear();
            MarginTopItem = 10;
            foreach (var item in items)
            {
                Inventory.Children.Add(new CheckBox { Content = $"{item.ItemName}", Margin = new Thickness(10, MarginTopItem, 0, 0) });
                MarginTopItem += 20;
            }

            foreach (var inventoryItem in Inventory.Children)
            {
                var checkBoxItem = inventoryItem as CheckBox;
                if (i.Items != null)
                {
                    foreach (var unitItem in i.Items)
                    {
                        if ($"{checkBoxItem.Content}" == unitItem.ItemName)
                        {
                            checkBoxItem.IsChecked = true;
                        }
                    }
                }
            }
        }

        private void expUp_Click(object sender, RoutedEventArgs e)
        {
            var i = MongoExample.Find($"{ChangeUnit.SelectedValue}");
            i.Experience += 2000;
            MessageBox.Show(i.Experience.ToString(), exp.Maximum.ToString());
            if (i.Experience > exp.Maximum)
            {
                i.Level = i.Level + 1;
                lvlBox.Text = i.Level.ToString();
                exp.Value = i.Experience - exp.Maximum;
                exp.Maximum = i.Level * 3000;
                i.Experience = (int)exp.Value;
            }
             if (i.Experience < exp.Maximum)
            {
                exp.Value += 2000;
                i.Experience = (int)exp.Value;
            }
             if(i.Experience == exp.Maximum)
            {
                i.Level = i.Level + 1;
                exp.Maximum = i.Level* 3000;
                lvlBox.Text = i.Level.ToString();
                exp.Value = 0;
                i.Experience = 0;
            }
            MongoExample.ReplaceUnit($"{ChangeUnit.SelectedValue}", i);
        }

        private void lvlBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.Parse(lvlBox.Text) % 3 == 0)
            {
                int a = int.Parse(lvlBox.Text) / 3;
                perks.Text = "";
                for (int ia = 0; ia< a; ia++)
                {
                    perks.Text = perks.Text + "перк ";
                }
            }
        }

        private void Shop_Click(object sender, RoutedEventArgs e)
        {
            string selected = (string)ChangeUnit.SelectedValue;
            var i = MongoExample.Find($"{ChangeUnit.SelectedValue}");
            Inventory inventory = new Inventory(equipment,(i as Unit),selected);
            inventory.ShowDialog();
        }
    }
}
