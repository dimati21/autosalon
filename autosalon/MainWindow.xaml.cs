using autosalon.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
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

namespace autosalon
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            App.DB = new Entities.AutosalonDB();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            App.dict = "Dark";
            var uri = new Uri(App.dict + ".xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            //string photo = "";
            //string pathPhoto = Environment.CurrentDirectory + "/Resources/";
            //List<Entities.Car> cars = App.DB.Car.ToList();
            //foreach (Entities.Car car in cars)
            //{
            //    if (String.IsNullOrEmpty(car.Image_var))
            //        photo = pathPhoto + "fake.png";
            //    else
            //    {
            //        photo = pathPhoto + car.Image_var;
            //        if (!File.Exists(photo))
            //            photo = pathPhoto + "fake.png";
            //    }
            //    car.Image_var = photo;
            //}
        }

        private void BtnTheme_Click(object sender, RoutedEventArgs e)
        {
            if (App.dict == "Dark")
                App.dict = "Light";
            else
                App.dict = "Dark";
            var uri = new Uri(App.dict + ".xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        private void OrderBtn_Click(object sender, RoutedEventArgs e)
        {

            View.OrderView createOrderView = new View.OrderView();
            this.Hide();
            createOrderView.ShowDialog();
            this.Show();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            View.AuthView createAuthView = new View.AuthView();
            this.Hide();
            createAuthView.ShowDialog();
            this.Show();
        }

        private void PriceList_Click(object sender, RoutedEventArgs e)
        {
            View.PriceListView createPriceListView = new View.PriceListView();
            this.Hide();
            createPriceListView.ShowDialog();
            this.Show();
        }
    }
}
