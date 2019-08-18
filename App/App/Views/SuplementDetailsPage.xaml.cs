using App.ViewModels;
using Models.Suplements;
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
    public partial class SuplementDetailsPage : ContentPage
    {
        private SuplementDetailsViewModel SuplementDetailsViewModel;

        public SuplementDetailsPage(Suplement suplement)
        {
            InitializeComponent();
            BindingContext = SuplementDetailsViewModel = new SuplementDetailsViewModel(suplement);
        }
    }
}