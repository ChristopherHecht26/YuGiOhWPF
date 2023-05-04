using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace YugiohWPF
{
    /// <summary>
    /// Interaktionslogik für Filter.xaml
    /// </summary>
    public partial class Filter : Window
    {
        public Filter()
        {
            InitializeComponent();
        }


        string requestURI = "https://db.ygoprodeck.com/api/v7/cardinfo.php?";
        string name;
        HttpClient httpClient = new HttpClient();

        private void txtBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            //https://db.ygoprodeck.com/api/v7/cardinfo.php?fname=
            name = "name=" + txtBoxSearch.Text;

        }

        private void cmbBox_CardType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtBoxATK_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtBoxDEF_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnSuchen_Click(object sender, RoutedEventArgs e)
        {
            requestURI = "https://db.ygoprodeck.com/api/v7/cardinfo.php?name=" + name + "&" + ;
            HttpResponseMessage httpResponse = httpClient.GetAsync(requestURI).Result;

            string response = httpResponse.Content.ReadAsStringAsync().Result;
            txtBlockTest.Text = response;
        }
    }
}
