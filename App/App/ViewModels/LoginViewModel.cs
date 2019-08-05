using App.Services;
using App.Views;
using Models.Requests.Token;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private ApiService _apiService = new ApiService("token", null);

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => {
                await Login();
            });
        }

        string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public ICommand LoginCommand { get; set; }

        async Task Login()
        {
            GetTokenPost tokenPost = new GetTokenPost { Email = Username, Password = Password };
            TokenResponse tokenResponse = await _apiService.Create<TokenResponse>(tokenPost);

            Application.Current.Properties["access_token"] = tokenResponse.AccessToken;
            Application.Current.MainPage = new MainPage();
        }
    }
}
