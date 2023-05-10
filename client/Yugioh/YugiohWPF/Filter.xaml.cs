using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
         ObservableCollection<card> cardinfolist = new ObservableCollection<card>();
        ObservableCollection<card> deckinfolist = new ObservableCollection<card>();

        int cardcount = 0;

        public Filter()
        {
            InitializeComponent();
            lvKarten.ItemsSource = cardinfolist;
            lvKartenDeck.ItemsSource = deckinfolist;
        }


        string requestURI = "https://db.ygoprodeck.com/api/v7/cardinfo.php?";
        string name;
        string type = "&type=";
        string atk;
        string def;
        public string description;
        string attribute = "&attribute=";
        string race = "&race=";
        string level = "&level=";

        HttpClient httpClient = new HttpClient();

        private void txtBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            //https://db.ygoprodeck.com/api/v7/cardinfo.php?fname=
            name = txtBoxSearch.Text;

        }



        private void btnSuchen_Click(object sender, RoutedEventArgs e)
        {
            cardinfolist.Clear();
            if (chbx_filtersearch_enable.IsChecked == true)
            {
                if (txtBoxATK.Text == "" && txtBoxDEF.Text == "")
                {
                    requestURI = "https://db.ygoprodeck.com/api/v7/cardinfo.php?fname=" + name + type +  attribute  + race +  level;
                }
                else
                {
                    requestURI = "https://db.ygoprodeck.com/api/v7/cardinfo.php?fname=" + name + type + "&atk=" + atk + "&def=" + def +  attribute +  race +  level;
                }
            }
            if(chbx_filtersearch_enable.IsChecked == false)
            {
                requestURI = "https://db.ygoprodeck.com/api/v7/cardinfo.php?fname=" + name ;
            }
            
            
            HttpResponseMessage httpResponse = httpClient.GetAsync(requestURI).Result;

            string response = httpResponse.Content.ReadAsStringAsync().Result;

            Root JSON_Objekte = JsonConvert.DeserializeObject<Root>(response);

            if(response == "{\"error\":\"No card matching your query was found in the database. Please see https:\\/\\/db.ygoprodeck.com\\/api-guide\\/ for syntax usage.\"}")
            {
                MessageBox.Show("Keine Karte gefunden");
            }

            else
            {
                int k = 0;
                
                foreach(YugiohWPF.Info i in JSON_Objekte.data)
                {
                    if(k < 11)
                    {
                        if (JSON_Objekte.data[k] != null)
                        {
                            cardinfolist.Add(new card()
                            {
                                name = JSON_Objekte.data[k].name.ToString(),
                                type = JSON_Objekte.data[k].type.ToString(),
                                //frameType = JSON_Objekte.data[0].frameType.ToString(),
                                desc = JSON_Objekte.data[k].desc.ToString(),
                                atk = JSON_Objekte.data[k].atk.ToString(),
                                def = JSON_Objekte.data[k].def.ToString(),
                                level = JSON_Objekte.data[k].level.ToString(),
                                race = JSON_Objekte.data[k].race.ToString(),
                                //attribute = JSON_Objekte.data[k].attribute.ToString(),
                                //archetype = JSON_Objekte.data[0].archetype.ToString(),
                                cardimage = JSON_Objekte.data[k].card_images[0].image_url.ToString()

                            });
                        }
                        k++;
                    }
                    else { return; }
                    
                }
                
            }
            
        }

        private void lvKarten_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            txtb_desc.Text = cardinfolist[lvKarten.SelectedIndex].desc;
        }

        private void btn_add_card_Click(object sender, RoutedEventArgs e)
        {
            if(cardcount >= 60)
            {
                MessageBox.Show("Maximale Kartenmenge überschritten um : " + (cardcount - 60));
            }
            if (lvKarten.SelectedIndex == -1) 
            {
                MessageBox.Show("Bitte Karte auswählen");
            }
            else
            {
                deckinfolist.Add(cardinfolist[lvKarten.SelectedIndex]);
                cardcount++;
                txtb_count.Text = "Karten : " + cardcount.ToString();
                brn_delete.IsEnabled = true;
            }
            
        }

        private void btn_close_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void brn_delete_Click(object sender, RoutedEventArgs e)
        {
            if(lvKartenDeck.SelectedIndex == -1)
            {
                MessageBox.Show("Bitte eine Karte auswählen");
            }
            else
            {
                deckinfolist.Remove(deckinfolist[lvKartenDeck.SelectedIndex]);
                cardcount--;
                txtb_count.Text = "Karten : " + cardcount.ToString();
            }
            
            

            if (cardcount == 0)
            {
                brn_delete.IsEnabled = false;
            }
            else
            {
                lvKartenDeck.SelectedIndex = cardcount - 1;
            }
            
            
        }
        private void txtBoxATK_TextChanged(object sender, TextChangedEventArgs e)
        {
            atk = txtBoxATK.Text;

        }

        private void txtBoxDEF_TextChanged(object sender, TextChangedEventArgs e)
        {
            def = txtBoxDEF.Text;
        }


        private void cmbBox_Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = (ComboBoxItem)cmbBox_Type.SelectedItem;
            if (String.Compare(cbi.Content.ToString(),"Alle") == 0)
            {
                type = "";
            }
            else
            {
                type = "&type=" + cbi.Content.ToString();

            }
        }

        private void cmbBox_Attribute_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = (ComboBoxItem)cmbBox_Attribute.SelectedItem;
            if(String.Compare(cbi.Content.ToString(),"Alle") == 0)
            {
                attribute = "";
            }
            else
            {
                attribute = "&attribute=" + cbi.Content.ToString();
            }
            
        }

        private void cmbBox_Race_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = (ComboBoxItem)cmbBox_Race.SelectedItem;
            if (String.Compare(cbi.Content.ToString(), "Alle") == 0)
            {
                race = "";
            }
            else
            {
                race =  "&race=" +cbi.Content.ToString();
            }
        }

        private void cmbBox_Level_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = (ComboBoxItem)cmbBox_Level.SelectedItem;
            if (String.Compare(cbi.Content.ToString(), "Alle") == 0)
            {
                level = "";
            }
            else
            {
                level =  "&level=" + cbi.Content.ToString();
            }
        }

        private void lvKartenDeck_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            txtb_desc.Text = cardinfolist[lvKartenDeck.SelectedIndex].desc;
        }
    }
}
