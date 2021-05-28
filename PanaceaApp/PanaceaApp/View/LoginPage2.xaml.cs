using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PanaceaApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage2 : ContentPage
    {
        public LoginPage2()
        {
            InitializeComponent();
        }

        private void SignupTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignUpPage2());
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}