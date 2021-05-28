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
    public partial class SignUpPage2 : ContentPage
    {
        public SignUpPage2()
        {
            InitializeComponent();
        }

        private void gobacktologin(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}