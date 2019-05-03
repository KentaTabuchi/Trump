using System;
using System.Collections.Generic;
using System.Diagnostics;
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


namespace Trump
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool
        DeleteObject(IntPtr hObject);

        Deck deck;
        Card SelectedCard; //選択中のカード
        private Image[] images;//Imageコントロールを動的生成するための配列
        public MainWindow()
        {
            InitializeComponent();
            deck = new Deck();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int number;
            Suit suit;
            
            Enum.TryParse(ComboBox_Suit.Text,out suit);
            if (suit.Equals(Suit.jocker))
            {
                number = 0;
            }
            else
            {
                number = Int32.Parse(ComboBox_Number.Text);
            }
            SelectedCard = deck.Cards.Find(m => m.Number == number && m.Suit.Equals(suit));
            Image1.Source = SelectedCard.ImageSource;

            images = new Image[6];
            for (int i = 1; i < images.Length; i++) {
                images[i] = new Image();
                images[i].Name = "Img" + i.ToString();
                number = i;
                Card card2 = deck.Cards.Find(m => m.Number == number && m.Suit.Equals(suit));
                images[i].Source = card2.ImageSource;
                images[i].Width = 60;
                images[i].Height = 90;

                myStackPanel01.Children.Add(images[i]);
                
            }
        }

        private void ComboBox_Number_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i < 14; i++)
            {
                ComboBox_Number.Items.Add(i.ToString());
            }
        }

        private void ComboBox_Suit_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                ComboBox_Suit.Items.Add(suit.ToString());
            }
        }
        /// <summary>
        /// これを押すとカードが裏返る実験
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SelectedCard.ReverseCard();
            Image1.Source = SelectedCard.ImageSource;
        }
    }
}
