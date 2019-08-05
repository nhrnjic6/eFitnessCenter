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
    public partial class WorkoutsPage : ContentPage
    {
        public WorkoutViewModel WorkoutViewModel;

        public WorkoutsPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = WorkoutViewModel = new WorkoutViewModel();
            await WorkoutViewModel.LoadWorkoutTypes();
            await WorkoutViewModel.LoadWorkouts();
        }
    }
}