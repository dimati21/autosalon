using autosalon.Entities;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace autosalon.View
{
    /// <summary>
    /// Логика взаимодействия для OrderView.xaml
    /// </summary>
    public partial class OrderView : Window
    {
        public int summ = 0;
        public int secondsumm = 0;
        public OrderView(int value)
        {
            InitializeComponent();
            summ = value;
        }
        private void ShowCars()
        {

            List<Entities.Car> cars = App.DB.Car.ToList();
            if (ListCreatore.SelectedIndex > 0)
            {
               cars = cars.Where(pr => pr.CreatoreID == ListCreatore.SelectedIndex).ToList();
            }
            foreach (Entities.Car car in cars)
            {
                if(!car.Image_var.Contains(Environment.CurrentDirectory))
                    car.Image_var = Environment.CurrentDirectory + "/Resources/Images/" + car.Image_var;
            }
            ListCar.ItemsSource = cars;
            
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Summ.Content = summ;
            //var uri = new Uri($"/View/{App.dict}.xaml", UriKind.Relative);
            //ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            //Application.Current.Resources.Clear();
            //Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            //List<Entities.Creatore> categories = App.DB.Creatore.ToList();
            //Entities.Creatore creatore = new Entities.Creatore();
            //creatore.CreatoreName = "Все марки";
            //creatore.CreatoreID = 0;
            //categories.Insert(0, creatore);
            //ListCreatore.ItemsSource = categories;
            //ListCreatore.DisplayMemberPath = "CreatoreName";
            //ListCreatore.SelectedValuePath = "CreatoreID";
            //ShowCars();
        }

        private void CreateOrder_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            secondsumm = rnd.Next(0, 10000);
            View.CreateOrderView createOrderView = new View.CreateOrderView();
            createOrderView.Owner = this;
            this.Hide();
            createOrderView.ShowDialog();
        }

        private void ListCreatore_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowCars();
        }

        private void butInOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Activated(object sender, EventArgs e)
        {
            Summ.Content = summ;
            var uri = new Uri($"/View/{App.dict}.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            List<Entities.Creatore> categories = App.DB.Creatore.ToList();
            Entities.Creatore creatore = new Entities.Creatore();
            creatore.CreatoreName = "Все марки";
            creatore.CreatoreID = 0;
            categories.Insert(0, creatore);
            ListCreatore.ItemsSource = categories;
            ListCreatore.DisplayMemberPath = "CreatoreName";
            ListCreatore.SelectedValuePath = "CreatoreID";
            ShowCars();
        }
    }
}
