using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace autosalon
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string login = "admin";
        public static string password = "admin";
        public static string dict;
        public static Entities.AutosalonDB DB;

    }
}
