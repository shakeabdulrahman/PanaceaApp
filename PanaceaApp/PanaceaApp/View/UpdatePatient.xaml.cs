using PanaceaApp.Model;
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
    public partial class UpdatePatient : ContentPage
    {
        UpdateVM wtf;
        public UpdatePatient(Patients patients)
        {
            InitializeComponent();

            wtf = Resources["wtfe"] as UpdateVM;

            wtf.Patients1 = patients;
        }
    }
}