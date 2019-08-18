using App.Services;
using App.Views;
using Models.Requests;
using Models.Suplements;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App.ViewModels
{
    public class SuplementViewModel : BaseViewModel
    {
        private ApiService suplementsApiService;
        private ApiService suplementTypeApiService;
        private SuplementType _suplementType;
        private Suplement _selectedSuplement;

        public INavigation Navigation { get; set; }

        public SuplementType SuplementType
        {
            get { return _suplementType; }
            set { SetProperty(ref _suplementType, value); var _ = LoadSuplements(_suplementType); }
        }

        public SuplementViewModel()
        {
            string token = (string) Application.Current.Properties["access_token"];
            suplementsApiService = new ApiService("suplements", token);
            suplementTypeApiService = new ApiService("suplementType", token);
        }

        public ObservableCollection<Suplement> Suplements { get; set; } = new ObservableCollection<Suplement>();
        public ObservableCollection<SuplementType> SuplementTypes { get; set; } = new ObservableCollection<SuplementType>();

        public Suplement SelectedSuplement
        {
            get { return _selectedSuplement; }
            set
            {   
                SetProperty(ref _selectedSuplement, value);
                if(_selectedSuplement != null)
                {
                    try
                    {

                    _ = Navigation.PushAsync(new SuplementDetailsPage(_selectedSuplement));
                    }catch(Exception e)
                    {

                    }
                }
            }
        }
        
        public async Task OnPickerIndexChanged()
        {
            await LoadSuplements(SuplementType);
        }

        public async Task LoadSuplements(SuplementType suplementType)
        {
            SuplementSearchParams searchParams = new SuplementSearchParams();

            if(suplementType != null)
            {
                searchParams.Type = suplementType.Type;
            }

            Suplements.Clear();
            List<Suplement> suplements = await suplementsApiService.GetAll<List<Suplement>>(searchParams);
            foreach(var suplement in suplements)
            {
                Suplements.Add(suplement);
            }
        }

        public async Task LoadSuplemenTypes()
        {
            List<SuplementType> suplementTypes = await suplementTypeApiService.GetAll<List<SuplementType>>(null);
            foreach (var suplementType in suplementTypes)
            {
                SuplementTypes.Add(suplementType);
            }
        }
    }
}
