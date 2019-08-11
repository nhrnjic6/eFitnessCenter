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
    public partial class WorkoutAdviceTrainerPage : ContentPage
    {
        public WorkoutAdviceTrainerViewModel WorkoutAdviceViewModel { get; set; }

        public WorkoutAdviceTrainerPage()
        {
            InitializeComponent();
            BindingContext = WorkoutAdviceViewModel = new WorkoutAdviceTrainerViewModel();
            WorkoutAdviceViewModel.Navigation = Navigation;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await WorkoutAdviceViewModel.LoadAdvices();
            await WorkoutAdviceViewModel.LoadTrainers();
        }
    }
}