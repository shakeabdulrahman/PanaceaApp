using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Firestore;
using Java.Util;
using PanaceaApp.Model;
using PanaceaApp.ViewModel.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(PanaceaApp.Droid.Dependencies.Firestore))]
namespace PanaceaApp.Droid.Dependencies
{
    class Firestore : Java.Lang.Object, IFirestore, IOnCompleteListener
    {
        public IntPtr Handle => throw new NotImplementedException();

        List<Patients> patients;
        bool hasreadvalue = false;

        public Firestore()
        {
            patients = new List<Patients>();
        }


        public async Task<bool> DeleteSubscription(Patients patients)
        {
            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("Patients");
                collection.Document(patients.Id).Delete();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool InsertSubscription(Patients patients)
        {
            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("Patients");
                var document = new JavaDictionary<string, Java.Lang.Object>
                {
                   {"author", Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid },
                   {"Patient Name", patients.PatientName },
                   {"Bed Number", patients.BedNumber },
                   {"Admitted Date", DateToNative(patients.AdmittedDate) },
                   //{"Contact Details", patients.Contact }
                };

                collection.Add(document);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IList<Patients>> ReadSubscription()
        {
            try
            {
                hasreadvalue = false;
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("Patients");
                var query = collection.WhereEqualTo("author", Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid);
                query.Get().AddOnCompleteListener(this);

                for (int i = 0; i < 25; i++)
                {
                    await System.Threading.Tasks.Task.Delay(100);
                    if (hasreadvalue == true)
                        break;
                }
                return patients;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UpdateSubscription(Patients patients)
        {
            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("Patients");
                collection.Document(patients.Id).Update("Bed Number", patients.BedNumber);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static Date DateToNative(DateTime date)
        {
            long timeutcinmillisecond = (long)date.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
            return new Date(timeutcinmillisecond);
        }

        /*public static DateTime NativeToDatetime(Date date)
        {
            DateTime reference = System.TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0));
            return reference.AddMilliseconds(date.Time);
        }*/

        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            if (task.IsSuccessful)
            {
                var document = (QuerySnapshot)task.Result;

                patients.Clear();
                foreach (var doc in document.Documents)
                {
                    var patientss = new Patients
                    {
                        PatientName = doc.Get("Patient Name").ToString(),
                        UserId = doc.Get("author").ToString(),
                        //Contact = doc.Get("Contact Details").ToString(),
                        // = doc.Get("Address").ToString(),
                        BedNumber = doc.Get("Bed Number").ToString(),
                        //SubscribedDate = NativeToDatetime(doc.Get("subscribeddate") as Date)
                        Id = doc.Id
                    };
                    patients.Add(patientss);
                }
                hasreadvalue = true;
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Error", "Something went wrong, please try again", "Okay");
            }
        }
    }
}