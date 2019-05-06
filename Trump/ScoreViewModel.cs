using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Trump
{
    /// <summary>
    /// 点数状況のデータをプロパティに保持して画面のラベルとバインディングするクラス。
    /// </summary>
    class ScoreViewModel:INotifyPropertyChanged
    {
        private int playerScore;

        public event PropertyChangedEventHandler PropertyChanged = null;

        public int PlayerScore {
            get => playerScore;
            set { playerScore = value;
                OnPropertyChanged(nameof(PlayerScore));
            } }

        public ScoreViewModel() {
            playerScore = 5;
        }
        protected void OnPropertyChanged(string info)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
   
}
