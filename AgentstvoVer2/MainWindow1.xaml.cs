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
    /// Логика взаимодействия для MainWindow1.xaml
    /// </summary>
    public partial class MainWindow1 : Window
    {
        public MainWindow1()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AgentstvoEntities3 model = new AgentstvoEntities3();
            try
            {
                var userobj = model.Users.FirstOrDefault(x => x.Name == usernameTextBox.Text && x.Password == passwordBox.Password);
                if (userobj == null)
                {
                    MessageBox.Show("Такого пользователя нет!", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    AccountHelpClass.Id = userobj.ID_Users;
                    switch (userobj.ID_Doljnost)
                    {
                        case 1:
                            var manager = new Meneger();
                            manager.Show();
                            this.Close();
                            break;
                        case 2:
                            var admin = new Admin();
                            admin.Show();
                            this.Close();
                            break;
                        default:
                            MessageBox.Show("Данные не обнаружены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message.ToString(), "Критическая ошибка работы приложения", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
