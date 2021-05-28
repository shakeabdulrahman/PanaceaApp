using PanaceaApp.ViewModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PanaceaApp.Model
{
    public class Patients : INotifyPropertyChanged
    {
        
        public string UserId { get; set; }
        public string PatientName { get; set; }

        public string BedNumber { get; set; }

        public DateTime AdmittedDate { get; set; }
        public string Contact { get; set; }

        public string Id { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
