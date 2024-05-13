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

namespace autosalon.View
{
    public partial class PriceListView : Window
    {
        List<Entities.Car> cars;
        public PriceListView()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //var uri = new Uri($"/View/{App.dict}.xaml", UriKind.Relative);
            //ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            //Application.Current.Resources.Clear();
            //Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            //List<Entities.Car> cars = App.DB.Car.ToList();
            //ListProd.ItemsSource = cars;
            //SortPrice.SelectedIndex = 0;
            //List<Entities.Creatore> categories = App.DB.Creatore.ToList();
            //Entities.Creatore creatore = new Entities.Creatore();
            //creatore.CreatoreName = "Все марки";
            //creatore.CreatoreID = 0;
            //categories.Insert(0, creatore);	
            //Category_Sort.ItemsSource = categories;	
            //Category_Sort.DisplayMemberPath = "CreatoreName";	
            //Category_Sort.SelectedValuePath = "CreatoreID"; 		

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
        private void SortPrice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowProduct();
        }

        private void Category_Sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowProduct();
        }

        private void Search_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShowProduct();
        }
        private void ShowProduct()
        {
            cars = App.DB.Car.ToList();
            int countAll = cars.Count;
            if (SortPrice.SelectedIndex == 1)
            {
                cars = cars.OrderBy(p => p.Price).ToList();
            }
            if (SortPrice.SelectedIndex == 2)
            {
                cars = cars.OrderByDescending(p => p.Price).ToList();
            }
            if (Category_Sort.SelectedValue != null && (int)Category_Sort.SelectedValue > 0)
            {
                cars = cars.Where(p => p.CreatoreID == (int)Category_Sort.SelectedValue).ToList();
            }
            string search = Search_Text.Text.ToLower();
            if (search.Length > 0)
            {
                cars = cars.Where(p => p.Name.ToLower().Contains(search)).ToList();
            }
            int countFilter = cars.Count;
            Count.Text = countFilter.ToString() + "/" + countAll.ToString();
            ListProd.ItemsSource = cars;
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            var uri = new Uri($"/View/{App.dict}.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            //List<Entities.Car> cars = App.DB.Car.ToList();
            //ListProd.ItemsSource = cars;
            SortPrice.SelectedIndex = 0;
            List<Entities.Creatore> categories = App.DB.Creatore.ToList();
            Entities.Creatore creatore = new Entities.Creatore();
            creatore.CreatoreName = "Все марки";
            creatore.CreatoreID = 0;
            categories.Insert(0, creatore);
            Category_Sort.ItemsSource = categories;
            Category_Sort.DisplayMemberPath = "CreatoreName";
            Category_Sort.SelectedValuePath = "CreatoreID";
            ShowProduct();

        }
    }
}
