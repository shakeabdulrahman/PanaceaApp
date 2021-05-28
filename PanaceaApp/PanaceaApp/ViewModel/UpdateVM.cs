using PanaceaApp.Model;
using PanaceaApp.ViewModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PanaceaApp.ViewModel
{
    class UpdateVM : INotifyPropertyChanged
    {
        private Patients patients1;

        public Patients Patients1
        {
            get { return patients1; }
            set 
            { 
                patients1 = value;
                BedNumber = Patients1.BedNumber;
                PatientName = Patients1.PatientName;
                OnPropertyChanged("Patients1");
            }
        }


        private string patientname;

        public string PatientName
        {
            get { return patientname; }
            set 
            { 
                patientname = value;
                Patients1.PatientName = patientname;
                OnPropertyChanged("PatientName");
                OnPropertyChanged("Patients1");
            }
        }



        private string bednumber;
        public string BedNumber
        {
            get { return bednumber; }
            set 
            { 
                bednumber = value;

                bool tonumber;
                int number;
                tonumber = int.TryParse(bednumber, out number);

                if (tonumber)
                {
                    if (number <= 360 && number >= 0)
                    {
                        bednumber = value;
                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("Note!", "Number should between 0 and 360", "Okay");
                    }
                }

                Patients1.BedNumber = bednumber;
                OnPropertyChanged("BedNumber");
                OnPropertyChanged("Patients1");
            }
        }

        public ICommand UpdateCommand { get; set; }

        public UpdateVM()
        {
            UpdateCommand = new Command(Update, CanUpdate);
        }

        private void Update(object parameter)
        {
            bool result = FirestoreHelper.UpdateSubscription(Patients1);

            if (result)
                App.Current.MainPage.Navigation.PopAsync();
            else
                App.Current.MainPage.DisplayAlert("Error", "Something went wrong, please try again", "Okay");
        }

        private bool CanUpdate(object parameter)
        {
            return !string.IsNullOrEmpty(BedNumber);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
