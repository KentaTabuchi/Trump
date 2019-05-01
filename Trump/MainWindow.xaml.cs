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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var deck = new Deck();
  
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
            Card card = deck.Cards.Find(m => m.Number == number && m.Suit.Equals(suit));
            Debug.Print("このカードは:"+card.Suit.ToString() + card.Number);
            IntPtr hbitmap = card.ImageBitmap.GetHbitmap();
            Image1.Source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hbitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            DeleteObject(hbitmap);
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
    }
}
