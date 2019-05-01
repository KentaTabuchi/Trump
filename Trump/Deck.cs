using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace Trump
{
    /// <summary>
    /// １組のカードセットを表すクラス
    /// </summary>
    class Deck
    {
        private List<Card> cards;
        /// <summary>
        /// ５２枚のカードを初期化してCardsリストへ格納する。
        /// ジョーカーは１枚だけで番号は存在しないが内部的に0とする。
        /// </summary>
        public Deck() {
            cards = new List<Card>();

            int number;
            foreach(Suit suit in Enum.GetValues(typeof (Suit))){
                if (suit.Equals(Suit.jocker))
                {
                    number = 0;
                    var card = new Card(suit, number);
                    cards.Add(card);
                    Debug.Print(suit.ToString() + number.ToString());
                }
                else {
                    for (int i = 1; i < 14; i++) {
                        number = i;
                        var card = new Card(suit, number);
                        cards.Add(card);
                        Debug.Print(suit.ToString() + number.ToString());
                    }
                }
                
            }
        }
        internal List<Card> Cards { get => cards; set => cards = value; }
    }
}
