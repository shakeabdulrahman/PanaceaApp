using PanaceaApp.Model;
using PanaceaApp.View;
using PanaceaApp.ViewModel.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PanaceaApp.ViewModel
{
    class ListPatientVM : INotifyPropertyChanged
    {

        private Patients selecteditem;

        public Patients SelectedItem
        {
            get { return selecteditem; }
            set 
            { 
                selecteditem = value;
                if (SelectedItem != null)
                {
                    App.Current.MainPage.Navigation.PushAsync(new UpdatePatient(selecteditem));
                }
            }
        }


       


        

        public ObservableCollection<Patients> Patients { get; set; }

        public ListPatientVM()
        {
            Patients = new ObservableCollection<Patients>();
        }

        

        public async void ReadCollection()
        {
            var patient = await FirestoreHelper.ReadSubscription();

            Patients.Clear();
            foreach (var s in patient)
            {
                Patients.Add(s);
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
