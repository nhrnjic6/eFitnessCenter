using App.Services;
using Models.Requests.Workout;
using Models.Trainers;
using Models.Workout;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App.ViewModels
{
    public class WorkoutAdviceViewModel : BaseViewModel
    {
        private ApiService adviceApiService;
        private ApiService trainersApiService;

        private WorkoutAdvice _workoutAdvice;
        private Trainer _trainer;

        public WorkoutAdviceViewModel()
        {
            string token = (string)Application.Current.Properties["access_token"];
            adviceApiService = new ApiService("workoutAdvice", token);
            trainersApiService = new ApiService("trainers", token);
        }

        public WorkoutAdvice WorkoutAdvice
        {
            get { return _workoutAdvice; }
            set
            {
                SetProperty(ref _workoutAdvice, value);
                if(_workoutAdvice != null)
                {
                    _= Application.Current.MainPage.DisplayAlert("Detalji Savjeta", _workoutAdvice.Message, "Ok");
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
