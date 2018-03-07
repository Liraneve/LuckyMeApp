using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.SimpleAudioPlayer.Abstractions;
using Xamarin.Forms;

namespace LuckyMeApp.Views
{
    public partial class CoinView : ContentPage
    {
        private Random rand = new Random();
        private ISimpleAudioPlayer player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
        private List<string> m_imagesList = new List<string>();

        public CoinView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            m_imagesList.Add("Head.png");
            m_imagesList.Add("Tail.png");
            player.Load("3D_Coin_Flip.wav");
            //CoinButon.Clicked += async (sender, args) =>
            //{
            //    uint duration = 2 * 1000;
            //    uint duration2 = 2 * 1000;
            //    player.Play();
                
            //    //await Task.WhenAll(
            //    ////CoinImage.RotateTo(90 * 360, duration)
            //    //CoinImage.RotateXTo(90 * 20, duration),
            //    ////CoinImage.RotateYTo(90 * 20, duration)
            //    //CoinImage.ScaleTo(1.5, duration / 2)
            //    // );
            //    //await Task.WhenAll(
            //    ////CoinImage.RotateTo(90 * 360, duration)
            //    //CoinImage.RotateXTo(90 *20, duration2),
            //    ////CoinImage.RotateYTo(90 * 20, duration)
            //    //CoinImage.ScaleTo(1, duration2 / 2)
            //    // );
            //    CoinImage.Source = m_imagesList[rand.Next(0, 2)];
            //};
        }

        private async void CoinButon_OnClicked(object sender, EventArgs e)
        {
            player.Play();
                uint duration = 2 * 1000;
                uint duration2 = 2 * 1000;
            await Task.WhenAll(
                ////CoinImage.RotateTo(90 * 360, duration)
                CoinImage.RotateXTo(90 * 20, duration),
                ////CoinImage.RotateYTo(90 * 20, duration)
                CoinImage.ScaleTo(1.5, duration / 2)
                 );
                await Task.WhenAll(
                ////CoinImage.RotateTo(90 * 360, duration)
                CoinImage.RotateXTo(90 *20, duration2),
                ////CoinImage.RotateYTo(90 * 20, duration)
                CoinImage.ScaleTo(1, duration2 / 2)
                 );
            CoinImage.Source = m_imagesList[rand.Next(0, 2)];
        }
    }
}
