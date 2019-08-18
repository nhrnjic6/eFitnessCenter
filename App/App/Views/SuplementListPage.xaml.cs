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
    public partial class SuplementListPage : ContentPage
    {
        private SuplementViewModel SuplementViewModel { get; set; }

        public SuplementListPage()
        {
            InitializeComponent();
            BindingContext = SuplementViewModel = new SuplementViewModel();
            SuplementViewModel.Navigation = Navigation;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await SuplementViewModel.LoadSuplemenTypes();
            await SuplementViewModel.LoadSuplements(null);
        }
    }
}