using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuckyMeApp.Views;
using Xamarin.Forms;

namespace LuckyMeApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void LottoryButton_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LottoryView());
        }

        private void DiceButton_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DiceView());
        }

        private void GroupsButton_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GroupsView());
        }

        private void CoinButton_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CoinView());
        }

        private void Exit_OnClicked(object sender, EventArgs e)
        {

        }
    }
}
