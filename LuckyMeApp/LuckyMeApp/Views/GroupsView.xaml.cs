using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuckyMeApp.ViewModel;
using Urho;
using Xamarin.Forms;

namespace LuckyMeApp.Views
{
    public partial class GroupsView : ContentPage
    {
        public GroupsView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await HelloWorldUrhoSurface.Show<GroupsViewModel>(new Urho.ApplicationOptions(assetsFolder: null) { Orientation = ApplicationOptions.OrientationType.LandscapeAndPortrait });


        }
    }
}
