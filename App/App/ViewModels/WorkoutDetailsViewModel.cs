using App.Services;
using Models.Requests.Workout;
using Models.Workout;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App.ViewModels
{
    public class WorkoutDetailsViewModel
    {
        private ApiService workoutScheduleApiService;
        public Workout Workout { get; set; }

        public ObservableCollection<WorkoutSchedule> WorkoutSchedules { get; set; } = new ObservableCollection<WorkoutSchedule>();

        public WorkoutDetailsViewModel() { }

        public WorkoutDetailsViewModel(Workout workout)
        {
            string token = (string)Application.Current.Properties["access_token"];
            workoutScheduleApiService = new ApiService("workoutSchedule", token);
            Workout = workout;
        }

        public async Task LoadSchedules()
        {
            WorkoutSchedules.Clear();

            WorkoutScheduleSearchParams searchParams = new WorkoutScheduleSearchParams
            {
                WorkoutId = Workout.Id.ToString()
            };

            List<WorkoutSchedule> workoutSchedules = await workoutScheduleApiService.GetAll<List<WorkoutSchedule>>(searchParams);

            foreach(var schedule in workoutSchedules)
            {
                WorkoutSchedules.Add(schedule);
            }
        }
    }
}
