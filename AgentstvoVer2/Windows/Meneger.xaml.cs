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

namespace AgentstvoVer2
{
    /// <summary>
    /// Логика взаимодействия для Meneger.xaml
    /// </summary>
    public partial class Meneger : Window
    {
        public Meneger()
        {
            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ContractBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ContractPage());
            FirstTextBox.Visibility = Visibility.Hidden;
            SecondTextBox.Visibility = Visibility.Visible;
        }

        private void AllContractsBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AllContractsPage());
        }
    }
}
