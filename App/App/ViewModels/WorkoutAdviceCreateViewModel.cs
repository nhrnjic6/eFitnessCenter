using App.Services;
using App.Views;
using Models.Clients;
using Models.Requests.Workout;
using Models.Workout;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App.ViewModels
{
    public class WorkoutAdviceCreateViewModel : BaseViewModel
    {
        private Client _client;
        private ApiService clientsApiService;
        private ApiService workoutAdviceApiService;
        private WorkoutAdvice WorkoutAdvice;

        private string _adviceContent;

        private bool _entryErrorVissible;

        public bool EntryErrorVissible
        {
            get { return _entryErrorVissible; }
            set { SetProperty(ref _entryErrorVissible, value); }
        }

        private bool _pickerErrorVissible;

        public bool PickerErrorVissible
        {
            get { return _pickerErrorVissible; }
            set { SetProperty(ref _pickerErrorVissible, value); }
        }

        public INavigation Navigation { get; set; }

        public WorkoutAdviceCreateViewModel(WorkoutAdvice workoutAdvice)
        {
            string token = (string)Application.Current.Properties["access_token"];
            clientsApiService = new ApiService("clients", token);
            workoutAdviceApiService = new ApiService("workoutAdvice", token);

            WorkoutAdvice = workoutAdvice;

            if(WorkoutAdvice != null)
            {
                AdviceContent = WorkoutAdvice.Message;
            }

            SaveAdviceCommand = new Command(async () =>
            {

                EntryErrorVissible = false;
                PickerErrorVissible = false;

                if (string.IsNullOrEmpty(AdviceContent))
                {
                    EntryErrorVissible = true;
                }

                if(Client == null)
                {
                    PickerErrorVissible = true;
                }

                if (PickerErrorVissible || EntryErrorVissible) return;

                WorkoutAdviceCreate adviceCreate = new WorkoutAdviceCreate
                {
                    ClientId = Client.Id,
                    Message = AdviceContent
                };

                if(WorkoutAdvice != null)
                {
                    await workoutAdviceApiService.Update<WorkoutAdvice>(WorkoutAdvice.Id, adviceCreate);
                }
                else
                {
                    await workoutAdviceApiService.Create<WorkoutAdvice>(adviceCreate);
                }

                EntryErrorVissible = false;
                PickerErrorVissible = false;

                await Navigation.PopAsync();
                await Navigation.PushAsync(new WorkoutAdviceTrainerPage());
            });

            DeleteAdviceCommand = new Command(async () =>
            {
                await workoutAdviceApiService.Delete(WorkoutAdvice.Id);
                await Navigation.PopAsync();
                await Navigation.PushAsync(new WorkoutAdviceTrainerPage());
            });
        }

        public ObservableCollection<Client> Clients { get; set; } = new ObservableCollection<Client>();

        public Client Client
        {
            get { return _client; }
            set
            {
                SetProperty(ref _client, value);
            }
        }

        public string AdviceContent
        {
            get { return _adviceContent; }
            set
            {
                SetProperty(ref _adviceContent, value);
            }
        }

        public bool DeleteButtonVissible
        {
            get { return AdviceContent != null; }
        }

        public async Task LoadClients()
        {
            Clients.Clear();
            List<Client> clients = await clientsApiService.GetAll<List<Client>>(null);

            if(WorkoutAdvice != null)
            {
                Client = clients.Where(x => x.Id == WorkoutAdvice.ClientId).FirstOrDefault();
            }

            foreach(var client in clients)
            {
                Clients.Add(client);
            }
        }

        public ICommand SaveAdviceCommand { get; set; }
        public ICommand DeleteAdviceCommand { get; set; }
    }
}
