using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILNumerics.Drawing;
using LuckyMeApp.ViewModel;
using Xamarin.Forms;
using static Xamarin.Forms.OpenGLView;
using OpenTK.Graphics.ES20;
using Plugin.SimpleAudioPlayer.Abstractions;
using Urho;


namespace LuckyMeApp.Views
{
    public partial class DiceView : ContentPage
    {
        DiceViewModel viewModel;
        List<string> m_imagesList = new List<string>();
        ISimpleAudioPlayer player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
        public DiceView()
        {
            //player.Load(@"C:\Users\liran\Downloads\Dice_SoundEffect.mp3");
            player.Load("Dice_SoundEffect.wav");
            InitializeComponent();
            BindingContext = viewModel = new DiceViewModel();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            player.Play();
            refreshDices();
        }

        private void Button_OnRemoveDice(object sender, EventArgs e)
        {
            if (viewModel.SelectedPicker > 0)
            {
                viewModel.SelectedPicker -= 1;
                refreshDices();
            }   
        }

        private void Button_OnAddDice(object sender, EventArgs e)
        {
            if (viewModel.SelectedPicker < 5)
            {
                viewModel.SelectedPicker += 1;
                refreshDices();
            }
                
        }

        private void refreshDices()
        {
            viewModel.GetImagesSourceAsync();
            Dice2.Source = null;
            Dice3.Source = null;
            Dice4.Source = null;
            Dice5.Source = null;
            Dice6.Source = null;
            if (viewModel.DiceImages.Count == 1)
            {
                Dice1.Source = viewModel.DiceImages[0].ImageSource;
                Dice1.Margin = new Thickness(130, 0, 0, 0);
            }

            if (viewModel.DiceImages.Count == 2)
            {
                Dice1.Source = viewModel.DiceImages[0].ImageSource;
                Dice2.Source = viewModel.DiceImages[1].ImageSource;
                Dice1.Margin = new Thickness(50, 0, 0, 0);
                Dice2.Margin = new Thickness(200, 0, 0, 0);
            }
            if (viewModel.DiceImages.Count == 3)
            {
                Dice1.Source = viewModel.DiceImages[0].ImageSource;
                Dice2.Source = viewModel.DiceImages[1].ImageSource;
                Dice3.Source = viewModel.DiceImages[2].ImageSource;
                Dice1.Margin = new Thickness(20, 0, 0, 0);
                Dice2.Margin = new Thickness(130, 0, 0, 0);
                Dice3.Margin = new Thickness(240, 0, 0, 0);
            }

            if (viewModel.DiceImages.Count == 4)
            {
                Dice1.Source = viewModel.DiceImages[0].ImageSource;
                Dice2.Source = viewModel.DiceImages[1].ImageSource;
                Dice3.Source = viewModel.DiceImages[2].ImageSource;
                Dice4.Source = viewModel.DiceImages[3].ImageSource;
                Dice1.Margin = new Thickness(20, 0, 0, 0);
                Dice2.Margin = new Thickness(130, 0, 0, 0);
                Dice3.Margin = new Thickness(240, 0, 0, 0);
                Dice4.Margin = new Thickness(130, 0, 0, 0);
            }

            if (viewModel.DiceImages.Count == 5)
            {
                Dice1.Source = viewModel.DiceImages[0].ImageSource;
                Dice2.Source = viewModel.DiceImages[1].ImageSource;
                Dice3.Source = viewModel.DiceImages[2].ImageSource;
                Dice4.Source = viewModel.DiceImages[3].ImageSource;
                Dice5.Source = viewModel.DiceImages[4].ImageSource;
                Dice1.Margin = new Thickness(20, 0, 0, 0);
                Dice2.Margin = new Thickness(130, 0, 0, 0);
                Dice3.Margin = new Thickness(240, 0, 0, 0);
                Dice4.Margin = new Thickness(50, 0, 0, 0);
                Dice5.Margin = new Thickness(200, 0, 0, 0);
            }

            if (viewModel.DiceImages.Count == 6)
            {
                Dice1.Source = viewModel.DiceImages[0].ImageSource;
                Dice2.Source = viewModel.DiceImages[1].ImageSource;
                Dice3.Source = viewModel.DiceImages[2].ImageSource;
                Dice4.Source = viewModel.DiceImages[3].ImageSource;
                Dice5.Source = viewModel.DiceImages[4].ImageSource;
                Dice6.Source = viewModel.DiceImages[5].ImageSource;
                Dice1.Margin = new Thickness(20, 0, 0, 0);
                Dice2.Margin = new Thickness(130, 0, 0, 0);
                Dice3.Margin = new Thickness(240, 0, 0, 0);
                Dice4.Margin = new Thickness(20, 0, 0, 0);
                Dice5.Margin = new Thickness(130, 0, 0, 0);
                Dice6.Margin = new Thickness(240, 0, 0, 0);
            }
        }
    }
}
