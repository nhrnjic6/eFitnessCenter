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
    public partial class WorkoutAdvicePage : ContentPage
    {
        public WorkoutAdviceViewModel WorkoutAdviceViewModel { get; set; }

        public WorkoutAdvicePage()
        {
            InitializeComponent();
            BindingContext = WorkoutAdviceViewModel = new WorkoutAdviceViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await WorkoutAdviceViewModel.LoadAdvices();
            await WorkoutAdviceViewModel.LoadTrainers();
        }
    }
}