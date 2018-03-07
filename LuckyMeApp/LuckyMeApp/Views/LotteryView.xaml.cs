using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuckyMeApp.ViewModel;
using Xamarin.Forms;

namespace LuckyMeApp.Views
{
    public partial class LottoryView : ContentPage
    {
        public LottoryView()
        {
            LotteryViewModel vm;
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = vm = new LotteryViewModel();

            ButtonRemoveBox.Clicked += (sender, args) =>
            {
                vm.RemoveBox();
            };

            ButtonAddBox.Clicked += (sender, args) =>
            {
                vm.AddBox();
            };
        }
    }
}
