using App.Services;
using App.Views;
using Models.Requests.Workout;
using Models.Workout;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App.ViewModels
{
    public class WorkoutViewModel : BaseViewModel
    {
        private ApiService workoutApiService;
        private ApiService workoutTypeApiService;
        private WorkoutType _workoutType;
        private string _duration;
        private Workout _selectedWorkout;
        
        public INavigation Navigation { get; set; }

        public List<string> DurationValues { get; set; }

        public ObservableCollection<Workout> Workouts { get; set; } = new ObservableCollection<Workout>();
        public ObservableCollection<WorkoutType> WorkoutTypes { get; set; } = new ObservableCollection<WorkoutType>();

        public Workout SelectedWorkout {
            get { return _selectedWorkout; }
            set
            {
                SetProperty(ref _selectedWorkout, value);
                if(Navigation != null)
                {
                    _ = Navigation.PushAsync(new WorkoutDetailsPage(_selectedWorkout));
                }
            }
        }

        public WorkoutType WorkoutType
        {
            get { return _workoutType; }
            set
            {
                SetProperty(ref _workoutType, value);
                _ = LoadWorkouts();
            }
        }

        public string Duration
        {
            get { return _duration; }
            set
            {
                SetProperty(ref _duration, value);
                _ = LoadWorkouts();
            }
        }

        public WorkoutViewModel()
        {
            string token = (string)Application.Current.Properties["access_token"];
            workoutApiService = new ApiService("workout", token);
            workoutTypeApiService = new ApiService("workoutType", token);

            DurationValues = new List<string> {"15", "25", "30", "45", "60", "90" };
        }

        public async Task LoadWorkouts()
        {
            Workouts.Clear();
            WorkoutSearchParams searchParams = new WorkoutSearchParams();

            if(WorkoutType != null)
            {
                searchParams.WorkoutType = WorkoutType.Name;
            }

            if (!string.IsNullOrEmpty(Duration))
            {
                searchParams.Duration = int.Parse(Duration);
            }

            List<Workout> workouts = await workoutApiService.GetAll<List<Workout>>(searchParams);
            foreach(var workout in workouts)
            {
                Workouts.Add(workout);
            }
        }

        public async Task LoadWorkoutTypes()
        {
            List<WorkoutType> workoutTypes = await workoutTypeApiService.GetAll<List<WorkoutType>>(null);
            foreach (var workoutType in workoutTypes)
            {
                WorkoutTypes.Add(workoutType);
            }
        }
    }
}
