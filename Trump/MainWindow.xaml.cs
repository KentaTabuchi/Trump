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
            controller.DistributeCard(deck, DealerHandPanel, 5);
            controller.DistributeCard(deck, PlayerHandPanel, 5);
        }
    }
}
