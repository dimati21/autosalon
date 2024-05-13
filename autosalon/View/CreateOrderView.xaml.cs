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
        public CreateOrderView()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            var uri = new Uri($"/View/{App.dict}.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
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
            OrderView order = this.Owner as OrderView;
            Summ.Content = order.secondsumm;
        }
    }
}
