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
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Windows.Controls.Primitives;

namespace AgentstvoVer2
{
    /// <summary>
    /// Логика взаимодействия для ContractPage.xaml
    /// </summary>
    public partial class ContractPage : Page
    {
        public ContractPage()
        {
            InitializeComponent();
            AppartmentsInsertName.ItemsSource = AgentstvoEntities3.GetContext().Appartments.ToList();
            ClientInsertName.ItemsSource= AgentstvoEntities3.GetContext().Clients.ToList();
            StatusInserName.ItemsSource= AgentstvoEntities3.GetContext().Options.ToList();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
    

            if (AppartmentsInsertName.SelectedIndex == -1)
            {
                errors.AppendLine("Укажите продукт");
            }
            if (StatusInserName.SelectedIndex == -1)
            {
                errors.AppendLine("Укажите статус объекта");
            }

            if (ClientInsertName.SelectedIndex == -1)
            {
                errors.AppendLine("Укажите клиента");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            var appartments = AppartmentsInsertName.SelectedItem as Appartments;
            var client = ClientInsertName.SelectedItem as Clients;
            var options= StatusInserName.SelectedItem as Options;

            var contract = new Contract
            {
                ID_House=appartments.ID_House,
                FIO = client.FIO,
                Options = options.Options1,
                DateNTime = DateTime.Parse(DateNTime.Text)
            };

            try
            {
                AgentstvoEntities3.GetContext().Contract.AddOrUpdate(contract);
                AgentstvoEntities3.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                this.NavigationService.Navigate(new ContractPage());  // Переход на эту же страницу после сохранения
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

      
    }
}
