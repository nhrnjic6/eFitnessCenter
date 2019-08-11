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
    public partial class WorkoutAdviceCreatePage : ContentPage
    {
        public WorkoutAdviceCreateViewModel WorkoutAdviceCreateViewModel { get; set; }

        public WorkoutAdviceCreatePage(WorkoutAdvice workoutAdvice)
        {
            InitializeComponent();
            BindingContext = WorkoutAdviceCreateViewModel = new WorkoutAdviceCreateViewModel(workoutAdvice);
            WorkoutAdviceCreateViewModel.Navigation = Navigation;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await WorkoutAdviceCreateViewModel.LoadClients();
        }
    }
}