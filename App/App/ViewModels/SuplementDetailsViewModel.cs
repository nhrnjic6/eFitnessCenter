using App.Services;
using Models.Requests.Suplements;
using Models.Suplements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App.ViewModels
{
    public class SuplementDetailsViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private Suplement _suplement;
        private string _selectedRating;
        private ApiService ratingApiService;
        private ApiService suplementsApiService;

        public SuplementDetailsViewModel(Suplement suplement)
        {
            _suplement = suplement;
            string token = (string)Application.Current.Properties["access_token"];
            ratingApiService = new ApiService("suplementRating", token);
            suplementsApiService = new ApiService("suplements", token);
        }

        public string[] RatingValues
        {
            get { return  new[]{ "1", "2", "3", "4", "5"}; }
        }

        public Suplement Suplement
        {
            get { return _suplement; }
            set
            {
                SetProperty(ref _suplement, value);
            }
        }

        public string SelectedRating
        {
            get { return _selectedRating; }
            set
            {
                SetProperty(ref _selectedRating, value);
                _ = RateSuplement(_selectedRating);
            }
        }

        public string UserSuplementRating
        {
            get
            {
                if(_suplement.UserRating == null || _suplement.UserRating < 1)
                {
                    return "Nema podatka";
                }
                else
                {
                    return _suplement.UserRating.ToString();
                }
            }
        }

        private async Task RateSuplement(string rating)
        {
            SuplementRatingCreate ratingCreate = new SuplementRatingCreate
            {
                Rating = int.Parse(rating),
                SuplementId = Suplement.Id
            };

            await ratingApiService.Create<object>(ratingCreate);
            Suplement = await suplementsApiService.GetById<Suplement>(Suplement.Id);
            OnPropertyChanged("UserSuplementRating");
        }
    }
}
