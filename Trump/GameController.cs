using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Trump
{
/// <summary>
///ゲームのロジックや進行の本体を集約するクラス 
/// </summary>
    class GameController
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool
        DeleteObject(IntPtr hObject);

     
        public GameController() {

        }
        /// <summary>
        /// 指定したスーツと数字のカードをデッキから１枚取り出す。
        /// </summary>
        /// <param name="deck"></param>
        /// <param name="suit"></param>
        /// <param name="number"></param>
        /// <returns></returns>　取り出したカード
        public Card DrawCard(Deck deck, Suit suit, int number) {

            if (suit.Equals(Suit.jocker))
            {
                number = 0;
            }
        //ここに引いたカードをデッキから除く処理を加える。
            return deck.Cards.Find(m => m.Number == number && m.Suit.Equals(suit));
            
        }

        /// <summary>
        /// 手札をデッキから配る。
        /// イメージコントロールを動的に生成して引いたカードをイメージに割り当てて画面に表示する。
        /// </summary>
        /// <param name="deck"></param>山札になるデッキ
        /// <param name="panel"></param>画面のどのパネルにイメージ画像を表示するか
        /// <param name="cardsNumber"></param>
        /// <returns></returns>　配られた手札のリスト。
        public List<Card> DistributeCard(Deck deck,int cardsNumber) {

            System.Threading.Thread.Sleep(15);

            var Cards = new List<Card>();
            var random1 = new Random();
            var random2 = new Random();
            
            for (int i = 0; i < cardsNumber; i++)
            {
                int number;
                number = 1+ random1.Next(14);
                Suit suit = (Suit)random2.Next(5);
                var card = DrawCard(deck, suit, number);//山札から一枚引く
                Cards.Add(card);//引いたカードを手札へ加える
                
            }
            return Cards;
        }
        public List<Image> PrintCardImage(List<Card> Cards,Panel panel) {

            const int CARD_WIDTH = 60;
            const int CARD_HEIGHT = 90;

            var images = new List<Image>();
            int i=0;
            foreach (Card card in Cards)
            {
                
                var image = new Image();
                image.Name = "Img" + i.ToString();
                image.Source = card.ImageSource;
                image.Width = CARD_WIDTH;
                image.Height = CARD_HEIGHT;

                panel.Children.Add(image);
                images.Add(image);
                i++;

            }
            return images;
        }
    }
}
