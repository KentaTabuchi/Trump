using System.Windows;

namespace Trump
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private ScoreViewModel scoreViewModel;
        public MainWindow()
        {
            InitializeComponent();
            scoreViewModel = new ScoreViewModel();
            this.DataContext = scoreViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var deck = new Deck();
            var controller = new GameController();
            var dealerCards = controller.DistributeCard(deck, 5);
            var playerCards = controller.DistributeCard(deck, 5);
            controller.PrintCardImage( dealerCards,DealerHandPanel);
            controller.PrintCardImage( playerCards,PlayerHandPanel);

        }
    }
}
