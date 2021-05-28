using PanaceaApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PanaceaApp.ViewModel.Helper
{
    public interface IFirestore
    {
        bool InsertSubscription(Patients patients);
        Task<bool> DeleteSubscription(Patients patients);
        bool UpdateSubscription(Patients patients);
        Task<IList<Patients>> ReadSubscription();
    }
    public class FirestoreHelper
    {
        public static IFirestore firestore = DependencyService.Get<IFirestore>();
        public static Task<bool> DeleteSubscription(Patients patients)
        {
            return firestore.DeleteSubscription(patients);
        }

        public static bool InsertSubscription(Patients patients)
        {
            return firestore.InsertSubscription(patients);
        }

        public static Task<IList<Patients>> ReadSubscription()
        {
            return firestore.ReadSubscription();
        }

        public static bool UpdateSubscription(Patients patients)
        {
            return firestore.UpdateSubscription(patients);
        }
    }
}
