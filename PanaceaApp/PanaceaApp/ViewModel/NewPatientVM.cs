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
    class NewPatientVM : INotifyPropertyChanged
    {

        private string patientname;

        public string PatientName
        {
            get { return patientname; }
            set 
            { 
                patientname = value;
                OnPropertyChanged("PatientName");
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

                if(tonumber)
                {
                    if(number <=360 && number >=0)
                    {
                        bednumber = value;
                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("Note!", "Number should between 0 and 360", "Okay");
                    }
                }

                OnPropertyChanged("BedNumber");
            }
        }


        private string contact;

        public string Contact
        {
            get { return contact; }
            set 
            { 
                contact = value;
                OnPropertyChanged("Contact");
            }
        }


        public ICommand SaveCommand { get; set; }

        public NewPatientVM()
        {
            SaveCommand = new Command(Save, CanSave);
        }

        private bool CanSave(object parameter)
        {
            return !string.IsNullOrEmpty(PatientName) && !string.IsNullOrEmpty(BedNumber);
        }

        private void Save(object parameter)
        {
            bool result = FirestoreHelper.InsertSubscription(new Patients
            {
                Id = null,
                UserId = Auth.GetUserId(),
                PatientName = PatientName,
                BedNumber = BedNumber,
                AdmittedDate = DateTime.Now,
                //Contact = Contact
            });
            if (result)
            {
                App.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Error", "Something went wrong, please try again", "Okay");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
