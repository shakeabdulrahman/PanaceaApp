using PanaceaApp.View;
using PanaceaApp.ViewModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PanaceaApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if(!Auth.IsAuthenticated())
            {
                Task.Delay(300);
                App.Current.MainPage.Navigation.PushAsync(new LoginPage2());
            }
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}
