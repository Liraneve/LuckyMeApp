using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LuckyMeApp.ViewModel
{
    public class Lottory
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public int Number3 { get; set; }
        public int Number4 { get; set; }
        public int Number5 { get; set; }
        public int Number6 { get; set; }
        public int HardNumber { get; set; }
        public int RowNumber { get; set; }
    }



    class LotteryViewModel : INotifyPropertyChanged
    {
        #region OnPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Private

        private const int DefaultNumberOfBoxes = 10;
        private Random _rand = new Random();

        private string _numberOfBoxesTitle = "Number of boxes: " + DefaultNumberOfBoxes;
        private bool _isEnableButtonRemoveBox;
        private bool _isEnableButtonAddBox;


        private int SelectedNumberOfBoxes { get; set; } = DefaultNumberOfBoxes;

        private async Task GetNumbersAsync()
        {
            LottoryNumbers.Clear();
            for (int i = 0; i < SelectedNumberOfBoxes; i++)
            {
                List<int> randomNumbers = new List<int>();

                for (int j = 0; j < 6; j++)
                {
                    int number;
                    do number = _rand.Next(1, 37);
                    while (randomNumbers.Contains(number));

                    randomNumbers.Add(number);
                }
                Lottory temp = new Lottory();
                temp.Number1 = randomNumbers[0];
                temp.Number2 = randomNumbers[1];
                temp.Number3 = randomNumbers[2];
                temp.Number4 = randomNumbers[3];
                temp.Number5 = randomNumbers[4];
                temp.Number6 = randomNumbers[5];
                temp.HardNumber = _rand.Next(1, 7);
                temp.RowNumber = i + 1;
                LottoryNumbers.Add(temp);
                randomNumbers.Clear();
            }
        }

        private async Task AddBoxOfNumbers()
        {
            List<int> randomNumbers = new List<int>();

            for (int j = 0; j < 6; j++)
            {
                int number;
                do number = _rand.Next(1, 37);
                while (randomNumbers.Contains(number));

                randomNumbers.Add(number);
            }
            Lottory temp = new Lottory();
            temp.Number1 = randomNumbers[0];
            temp.Number2 = randomNumbers[1];
            temp.Number3 = randomNumbers[2];
            temp.Number4 = randomNumbers[3];
            temp.Number5 = randomNumbers[4];
            temp.Number6 = randomNumbers[5];
            temp.HardNumber = _rand.Next(1, 7);
            temp.RowNumber = SelectedNumberOfBoxes;
            LottoryNumbers.Add(temp);
        }

        private async Task RemoveBoxOfNumbers()
        {
            LottoryNumbers.Remove(LottoryNumbers.Last());
        }

        #endregion

        public LotteryViewModel()
        {
            GetNumbersAsync();
            IsEnableButtonRemoveBox = true;
            IsEnableButtonAddBox = true;
        }

        public ObservableCollection<Lottory> LottoryNumbers { get; } = new ObservableCollection<Lottory>();

        public bool IsEnableButtonRemoveBox
        {
            get { return _isEnableButtonRemoveBox; }
            set
            {
                _isEnableButtonRemoveBox = value;
                OnPropertyChanged(nameof(IsEnableButtonRemoveBox));
            }
        }

        public bool IsEnableButtonAddBox
        {
            get { return _isEnableButtonAddBox; }
            set
            {
                _isEnableButtonAddBox = value;
                OnPropertyChanged(nameof(IsEnableButtonAddBox));
            }
        }

        public string NumberOfBoxesTitle
        {
            get { return _numberOfBoxesTitle; }
            set
            {
                _numberOfBoxesTitle = value;
                OnPropertyChanged(nameof(NumberOfBoxesTitle));
            }
        }

        public async Task RemoveBox()
        {
            if (SelectedNumberOfBoxes == 14)
                IsEnableButtonAddBox = true;
            SelectedNumberOfBoxes = SelectedNumberOfBoxes - 1;
            if (SelectedNumberOfBoxes == 1)
                IsEnableButtonRemoveBox = false;
            NumberOfBoxesTitle = "Number of boxes: " + SelectedNumberOfBoxes;
            RemoveBoxOfNumbers();
        }




        public async Task AddBox()
        {
            if (SelectedNumberOfBoxes == 1)
                IsEnableButtonRemoveBox = true;
            SelectedNumberOfBoxes = SelectedNumberOfBoxes + 1;
            if (SelectedNumberOfBoxes == 14)
                IsEnableButtonAddBox = false;
            NumberOfBoxesTitle = "Number of boxes: " + SelectedNumberOfBoxes;
            AddBoxOfNumbers();
        }
    }
}
