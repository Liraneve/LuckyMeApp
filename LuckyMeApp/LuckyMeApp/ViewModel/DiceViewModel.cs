using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyMeApp.ViewModel
{
    public class Dice
    {
        public string ImageSource { get; set; }
    }
    class DiceViewModel
    {
        public ObservableCollection<Dice> DiceImages { get; } = new ObservableCollection<Dice>();
        private int m_numberOfDices=0;
        List<string> m_imagesList = new List<string>();

        public int SelectedPicker
        {
            get { return m_numberOfDices; }
            set { m_numberOfDices = value; }
        }

        public DiceViewModel()
        {
            m_imagesList.Add("Dice_num1.png");
            m_imagesList.Add("Dice_num2.png");
            m_imagesList.Add("Dice_num3.png");
            m_imagesList.Add("Dice_num4.png");
            m_imagesList.Add("Dice_num5.png");
            m_imagesList.Add("Dice_num6.png");
        }

        public async Task GetImagesSourceAsync()
        {
            DiceImages.Clear();
            Random rand = new Random();
            for (int i = 0; i <= m_numberOfDices; i++)
            {
                Dice temp = new Dice();
                temp.ImageSource = m_imagesList[rand.Next(0, 6)];
                DiceImages.Add(temp);
            }
        }
    }
}
