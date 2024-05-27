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
    /// <summary>
    /// Логика взаимодействия для CreateOrderView.xaml
    /// </summary>
    public partial class CreateOrderView : Window
    {
        OrderView createOrder;
        List<Classes.CarInOrder> listCarsInOrder;
        double summaOrder;
        public CreateOrderView()
        {
            InitializeComponent();
        }
        private void ShowOrder()
        {
            dgOrder.ItemsSource = null;
            dgOrder.ItemsSource = listCarsInOrder;//Отобразить список заказанных блюд
            summaOrder = 0;//Сначала сумму заказа обнуляем
            //Рассчитать сумму заказанных блюд из списка
            foreach (Classes.CarInOrder item in listCarsInOrder)
            {
                summaOrder += item.TotalPrice;
            }
            Summ.Content = "Сумма заказа " + Math.Round(summaOrder, 2);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            var uri = new Uri($"/View/{App.dict}.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            createOrder = this.Owner as OrderView;
            listCarsInOrder = createOrder.listCarsInOrder;//Получить список заказанных блюд
            ShowOrder();
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

        private void Window_Activated(object sender, EventArgs e)
        {
            
        }

        private void butDel_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Classes.CarInOrder selectCarsInOrder = btn.DataContext as Classes.CarInOrder;
            listCarsInOrder.Remove(selectCarsInOrder);
            selectCarsInOrder.TotalPrice = selectCarsInOrder.CarCount * selectCarsInOrder.Price;
            ShowOrder();
        }
    }
}
