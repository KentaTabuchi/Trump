using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Trump
{
    ///<summary>
    ///カードの種別（スーツ）を表す列挙子
    ///</summary>
    public enum Suit
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
    public enum Side
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
        private readonly string imgURL = "C:/Users/tabuchikenta/source/repos/Trump/Trump/Assets/trump.gif";
        static Graphics g; //元画像全体のイメージ

        /// <summary>
        /// コンストラクタで画像イメージを設定する。
        /// 全絵柄の１枚絵をクラス変数に保持して部分イメージを切り出して割り当てる。
        /// </summary>
        /// <param name="suit"></param>
        /// <param name="number"></param>
        public Card(Suit suit,int number){
            this.suit = suit;
            this.number = number;
            this.side = Side.back;

            if (g == null){
                var bitmap = new Bitmap(480, 630);
                var originalImage = Image.FromFile(imgURL);
                g = Graphics.FromImage(bitmap);
            }

        }
       
        public int Number { get => number; }
        internal Suit Suit { get => suit; }
        internal Side Side { get => side; set => side = value; }
    }
}
