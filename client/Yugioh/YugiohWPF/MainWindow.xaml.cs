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
        private int row_position = 0; //zeigt row postion (cursor)

        ColumnDefinition gridCol = new ColumnDefinition();

        private void add_card_to_deck()
        {

            //Erstellt eine "Karte" --> das hier muss zu einer echten Karte geändert werden (Label ist Platzalter)
            Label card1 = new Label();
            card1.Content = "Karte";
            card1.FontSize = 14;
            card1.FontWeight = FontWeights.Bold;

            //Karten setzen
            if(col_count < 15)
            {
                grd_cardholder.ColumnDefinitions.Add(new ColumnDefinition()); //erstellt eine neue dynamische Spalte
                Grid.SetRow(card1, row_position);
                Grid.SetColumn(card1, col_count);
                grd_cardholder.Children.Add(card1);
                col_count++;
            }
            if(col_count == 16)
            {
                grd_cardholder.RowDefinitions.Add(new RowDefinition());
                row_position++;
                Grid.SetRow(card1, 1);
                Grid.SetColumn(card1, col_count);
                grd_cardholder.Children.Add(card1);
                col_count = 0;
            }

            //Karten Count Hoch
            card_count++;
            lbl_Info.Content = "Deckinfo : " + card_count.ToString();

        }

        private void btn_Create_Click(object sender, RoutedEventArgs e)
        {
            add_card_to_deck();
        }
    }
}
