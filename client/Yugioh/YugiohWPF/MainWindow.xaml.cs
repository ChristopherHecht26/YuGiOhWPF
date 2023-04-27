using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

namespace YugiohWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private int card_count; //zählt die menge hinzugefügter Karten

        private int col_count; //zählt columns, um einen rechtzeitigen Umbruch einzufügen
        private int col_position_max; //zählt columns, sobald die 15 Spalten eingefügt sind
        private int row_position = 0; //zeigt row postion (cursor)
        public float temp;

        ColumnDefinition gridCol = new ColumnDefinition();
        RowDefinition rowCol = new RowDefinition();


        HttpClient httpClient = new HttpClient();

        
        private void send_requ()
        {
            string requestUri = "https://db.ygoprodeck.com/api/v7/cardinfo.php?name=Dark Magician";
            string jsonstring = "{'id':46986421,'name':'Dark Magician'}";

            HttpResponseMessage httpResponse = httpClient.GetAsync(requestUri).Result;

            string response = httpResponse.Content.ReadAsStringAsync().Result;

            Root JSON_Objekte = JsonConvert.DeserializeObject<Root>(response);


            MessageBox.Show(JSON_Objekte.data[0].card_images[0].image_url.ToString());

        }

        public class cardResponse
        {
            public string name { get; set; }
        }

        class Data
        {
            public int atk;
        }

        private void add_card_to_deck()
        {

            //Erstellt eine "Karte" --> das hier muss zu einer echten Karte geändert werden (Label ist Platzalter)
            TextBlock card1 = new TextBlock();
            card1.Text = "Karte" + card_count.ToString();
            card1.FontSize = 14;
            card1.FontWeight = FontWeights.Bold;
            card1.Background = Brushes.Beige;


            send_requ();


            //Karten setzen
            if (col_count == 10)
            {
                col_position_max++;
                if(col_position_max == 9)
                {
                    Grid.SetRow(card1, row_position);
                    Grid.SetColumn(card1, col_position_max);
                    grd_cardholder.Children.Add(card1);
                    card_count++;
                }

                if(col_position_max == 10)
                {
                    grd_cardholder.RowDefinitions.Add(new RowDefinition()); // erstellt dynamische reihe
                    row_position++;
                    col_position_max = 0;
                }
              
            }
            if(col_count < 10)
            {
                if(col_count == 0)
                {
                    grd_cardholder.RowDefinitions.Add(new RowDefinition()); // erstellt dynamische reihe
                    grd_cardholder.ColumnDefinitions.Add(new ColumnDefinition()); //erstellt eine neue dynamische Spalte
                    col_count++;

                    //Karten Count Hoch
                    Grid.SetRow(card1, row_position);
                    Grid.SetColumn(card1, col_position_max);
                    grd_cardholder.Children.Add(card1);
                    card_count++;
                }
                else 
                {
                    grd_cardholder.ColumnDefinitions.Add(new ColumnDefinition()); //erstellt eine neue dynamische Spalte
                    col_count++;
                    col_position_max++;
                }
                if(col_position_max == 9) 
                {
                    Grid.SetRow(card1, row_position);
                    Grid.SetColumn(card1, col_position_max);
                    grd_cardholder.Children.Add(card1);
                    card_count++;
                }
                
            }

            if(col_count > 1 & col_position_max != 9)
            {
                //Karten Count Hoch
                Grid.SetRow(card1, row_position);
                Grid.SetColumn(card1, col_position_max);
                grd_cardholder.Children.Add(card1);
                card_count++;
            }
            lbl_Info.Content = "Deckinfo :  Spaltencount : " + col_count.ToString() + "Spalte : " + col_position_max.ToString() + "reihen : " + grd_cardholder.RowDefinitions.Count.ToString();


        }

        private void btn_Create_Click(object sender, RoutedEventArgs e)
        {
            add_card_to_deck();
        }
    }
}
