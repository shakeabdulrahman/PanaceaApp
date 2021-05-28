using PanaceaApp.View;
using PanaceaApp.ViewModel.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PanaceaApp.ViewModel
{
    class MainVM
    {
        public ICommand SignoutCommand { get; set; }
        public ICommand GotoPatientlist { get; set; }

        public MainVM()
        {
            GotoPatientlist = new Command(CanNavigate);

            SignoutCommand = new Command(Signout);
        }

        private async void Signout(object parameter)
        {
            bool response = await App.Current.MainPage.DisplayAlert("", "Do you want to Logout?", "Yes", "No");
            if (response)
            {
                Auth.SignOut();
                await App.Current.MainPage.Navigation.PushAsync(new LoginPage2());
            }
            else
                return;
        }

        private void CanNavigate(object parameter)
        {
            App.Current.MainPage.Navigation.PushAsync(new ListOfPatients());
        }
    }
}
