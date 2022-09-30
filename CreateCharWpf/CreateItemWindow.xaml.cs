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
    /// Логика взаимодействия для CreateItemWindow.xaml
    /// </summary>
    public partial class CreateItemWindow : Window
    {
        Item Item { get; set; }

        public CreateItemWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ItemName.Text != "" && ItemCount.Text != "") { this.DialogResult = true; }
        }

        private void ItemCount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            {
                if (!Char.IsDigit(e.Text, 0))
                {
                    e.Handled = true;
                }
            }
        }
    }
}
