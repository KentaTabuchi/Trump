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
        private readonly string imgURL = "C:/Users/tabuchikenta/source/repos/Trump/Trump/Assets/trump.bmp";
        public static Bitmap originalBitmap; //元画像全体のイメージ
        private Bitmap imageBitmap;
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
            

            if (originalBitmap == null){
                originalBitmap = new Bitmap(480, 630);
                var originalImage = Image.FromFile(imgURL);
                originalBitmap = (Bitmap)originalImage;
               
            }
            imageBitmap = ImageRoi(originalBitmap,new Rectangle(0,0,60,90));//一枚あたりの大きさ

        }
        /// <summary>
        /// Bitmapの一部を切り出したBitmapオブジェクトを返す
        /// </summary>
        /// <param name="srcRect">元のBitmapクラスオブジェクト</param>
        /// <param name="roi">切り出す領域</param>
        /// <returns>切り出したBitmapオブジェクト</returns>
        public Bitmap ImageRoi(Bitmap src, Rectangle roi)
        {
            //////////////////////////////////////////////////////////////////////
            // srcRectとroiの重なった領域を取得（画像をはみ出した領域を切り取る）

            // 画像の領域
            var imgRect = new Rectangle(0, 0, src.Width, src.Height);
            // はみ出した部分を切り取る(重なった領域を取得)
            var roiTrim = Rectangle.Intersect(imgRect, roi);
            // 画像の外の領域を指定した場合
            if (roiTrim.IsEmpty == true) return null;

            //////////////////////////////////////////////////////////////////////
            // 画像の切り出し

            // 切り出す大きさと同じサイズのBitmapオブジェクトを作成
            var dst = new Bitmap(roiTrim.Width, roiTrim.Height, src.PixelFormat);
            // BitmapオブジェクトからGraphicsオブジェクトの作成
            var g = Graphics.FromImage(dst);
            // 描画先
            var dstRect = new Rectangle(0, 0, roiTrim.Width, roiTrim.Height);
            // 描画
            g.DrawImage(src, dstRect, roiTrim, GraphicsUnit.Pixel);
            // 解放
            g.Dispose();

            return dst;
        }

        public int Number { get => number; }
        internal Suit Suit { get => suit; }
        internal Side Side { get => side; set => side = value; }
        public Bitmap ImageBitmap { get => imageBitmap; set => imageBitmap = value; }
    }
}
