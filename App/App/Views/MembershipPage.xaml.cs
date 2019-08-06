using App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MembershipPage : ContentPage
    {
        public MembershipViewModel MembershipViewModel { get; set; }

        public MembershipPage()
        {
            InitializeComponent();
            BindingContext = MembershipViewModel = new MembershipViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await MembershipViewModel.LoadMemberships();
        }
    }
}