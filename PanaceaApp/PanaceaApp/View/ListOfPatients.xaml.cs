using PanaceaApp.ViewModel;
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
    public partial class ListOfPatients : ContentPage
    {
        ListPatientVM lp;
        public ListOfPatients()
        {
            InitializeComponent();

            lp = Resources["lpe"] as ListPatientVM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            lp.ReadCollection();
        }

        private void Add_Patient(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewPatient());
        }
    }
}