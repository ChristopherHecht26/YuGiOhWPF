using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
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
using YugiohWPF.Service;

namespace YugiohWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public string image;

        public MainWindow()
        {
            InitializeComponent();
        }

        public float temp;

        HttpClient httpClient = new HttpClient();

        private void btn_Test_Click(object sender, RoutedEventArgs e)
        {
            YugiohWPF.Filter filter = new Filter();
            filter.Show();
        }
        
    }
}
