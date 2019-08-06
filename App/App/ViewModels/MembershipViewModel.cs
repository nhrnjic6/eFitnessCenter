using App.Services;
using Models.Membership;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App.ViewModels
{
    public class MembershipViewModel
    {
        private ApiService membershipApiService;

        public ObservableCollection<MembershipPayment> MembershipPayments { get; set; } = new ObservableCollection<MembershipPayment>();

        public MembershipViewModel()
        {
            string token = (string)Application.Current.Properties["access_token"];
            membershipApiService = new ApiService("membershipPayments", token);
        }

        public async Task LoadMemberships()
        {
            MembershipPayments.Clear();

            List<MembershipPayment> membershipPayments = await membershipApiService.GetAll<List<MembershipPayment>>(null);
            foreach(var payment in membershipPayments)
            {
                MembershipPayments.Add(payment);
            }
        }
    }
}
