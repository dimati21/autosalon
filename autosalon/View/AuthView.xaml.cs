using autosalon.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace autosalon.View
{
    /// <summary>
    /// Логика взаимодействия для AuthView.xaml
    /// </summary>
    public partial class AuthView : Window
    {
        int k = 3;
        public AuthView()
        {
            InitializeComponent();
        }

        private void BtnTheme_Click(object sender, RoutedEventArgs e)
        {
            if (App.dict == "Dark")
                App.dict = "Light";
            else
                App.dict = "Dark";
            var uri = new Uri($"/View/{App.dict}.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var uri = new Uri($"/View/{App.dict}.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            PasswordTXTBox.Visibility = Visibility.Hidden;
            PasswordTXT.Visibility = Visibility.Visible;
        }

        private void Auth_Click(object sender, RoutedEventArgs e)
        {
            if (k == 0)
            {
                MessageBox.Show("Ваши попытки закончились.\nПододите 10 секунд.");
                Thread.Sleep(10000);
                k = 3;
                return;
            }
            List<Entities.User> users = App.DB.User.ToList();
            string login = LoginTXT.Text;
            string password = "";
            if (showPass.IsChecked == true)
            {
                password = PasswordTXTBox.Text;
            }
            else
            {
                password = PasswordTXT.Password;
            }

            Entities.User userSearch = App.DB.User.Where(u => u.Login == login && u.Password == password).ToList().FirstOrDefault();


            //if (LoginTXT.Text == App.login && PasswordTXT.Password == App.password)
            if (userSearch != null && k > 0)
            {
                MessageBox.Show($"Вы успешно авторизовались");
                View.KatalogView createKatalogView = new View.KatalogView();
                this.Hide();
                createKatalogView.ShowDialog();
            }
            else
            {
                k--;
                MessageBox.Show($"Неверный логин или пароль\nКоличество оставшихся попыток: {k}");
            }
        }

        private void showPass_Click(object sender, RoutedEventArgs e)
        {
            var CheckBox = sender as CheckBox;
            if (CheckBox.IsChecked.Value)
            {
                PasswordTXTBox.Text = PasswordTXT.Password;
                PasswordTXTBox.Visibility = Visibility.Visible;
                PasswordTXT.Visibility = Visibility.Hidden;
            }
            else
            {
                PasswordTXT.Password = PasswordTXTBox.Text;
                PasswordTXTBox.Visibility = Visibility.Hidden;
                PasswordTXT.Visibility = Visibility.Visible;
            }
        }
    }
}
