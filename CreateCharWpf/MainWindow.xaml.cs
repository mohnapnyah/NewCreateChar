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
        int MarginTopItem = 10;
        List<Item> items;

        public MainWindow()
        {
            InitializeComponent();
            items = new List<Item>();
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
                            (int)SliderIntellingence.Value);
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
            int freeEXP = 2000;
            if (exp.Maximum < i.Experience)
            {
                    i.Level += 1;
                    lvlBox.Text = (i.Level + 1).ToString();
                    freeEXP -= (int)exp.Maximum;
                    exp.Maximum += 3000;
                    exp.Value = 0;
                    freeEXP = 0;
                
                
            }
            else if (exp.Maximum > i.Experience)
            {
                exp.Value += 2000;
            }
            else
            {
                i.Level += 1;
                lvlBox.Text = (i.Level + 1).ToString();
                exp.Value = 0;
            }
        }
    }
}
