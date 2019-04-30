using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trump
{
    ///<summary>
    ///カードの種別（スーツ）を表す列挙子
    ///</summary>
    enum Suit
    {
        spade,
        heart,
        daiamond,
        club,
        jocker
    }
    /// <summary>
    /// カードの表裏を表す列挙子
    /// </summary>
    enum Side
    {
        front,
        back
    }
    ///<summary>
    ///トランプ一枚を表すクラス
    ///スーツと数字はコンストラクタ以外で変更不可。
    ///表裏のみゲーム中に変わる。
    ///</summary>
    class Card
    {
        private readonly Suit suit;
        private readonly int number;
        private Side side;

        public Card(Suit suit,int number){
            this.suit = suit;
            this.number = number;
            this.side = Side.back;
        }
       
        public int Number { get => number; }
        internal Suit Suit { get => suit; }
        internal Side Side { get => side; set => side = value; }
    }
}
