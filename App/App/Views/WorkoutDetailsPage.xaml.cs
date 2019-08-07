using App.ViewModels;
using Models.Workout;
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
    public partial class WorkoutDetailsPage : ContentPage
    {
        private WorkoutDetailsViewModel WorkoutDetailsViewModel;

        public WorkoutDetailsPage(Workout workout)
        {
            InitializeComponent();
            BindingContext = WorkoutDetailsViewModel = new WorkoutDetailsViewModel(workout);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await WorkoutDetailsViewModel.LoadSchedules();
        }
    }
}