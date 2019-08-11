using App.Services;
using App.Views;
using Models.Requests.Workout;
using Models.Trainers;
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
    public class WorkoutAdviceTrainerViewModel : BaseViewModel
    {
        private ApiService adviceApiService;
        private ApiService trainersApiService;

        private WorkoutAdvice _workoutAdvice;
        private Trainer _trainer;
        public INavigation Navigation { get; set; }

        public WorkoutAdviceTrainerViewModel()
        {
            string token = (string)Application.Current.Properties["access_token"];
            adviceApiService = new ApiService("workoutAdvice", token);
            trainersApiService = new ApiService("trainers", token);

            NewButtonClicked = new Command(async () =>
            {
                await Navigation.PushAsync(new WorkoutAdviceCreatePage(null));
            });
        }

        public WorkoutAdvice WorkoutAdvice
        {
            get { return _workoutAdvice; }
            set
            {
                SetProperty(ref _workoutAdvice, value);
                if(_workoutAdvice != null)
                {
                    _ = Navigation.PushAsync(new WorkoutAdviceCreatePage(_workoutAdvice));
                }
            }
        }

        public Trainer Trainer
        {
            get { return _trainer; }
            set
            {
                SetProperty(ref _trainer, value);
                if(_trainer != null)
                {
                    _= LoadAdvices();
                }
            }
        }

        public ICommand NewButtonClicked { get; set; }

        public ObservableCollection<WorkoutAdvice> WorkoutAdvices { get; set; } = new ObservableCollection<WorkoutAdvice>();
        public ObservableCollection<Trainer> Trainers { get; set; } = new ObservableCollection<Trainer>();


        public async Task LoadAdvices()
        {
            WorkoutAdvices.Clear();

            WorkoutAdviceQueryParams queryParams = new WorkoutAdviceQueryParams();
            if(Trainer != null)
            {
                queryParams.TrainerId = Trainer.Id;
            }

            List<WorkoutAdvice> workoutAdvices = await adviceApiService.GetAll<List<WorkoutAdvice>>(queryParams);
            foreach(var advice in workoutAdvices)
            {
                WorkoutAdvices.Add(advice);
            }
        }

        public async Task LoadTrainers()
        {
            Trainers.Clear();
            List<Trainer> trainers = await trainersApiService.GetAll<List<Trainer>>(null);
            foreach (var trainer in trainers)
            {
                Trainers.Add(trainer);
            }
        }
    }
}
