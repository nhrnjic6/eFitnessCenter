using App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            //MenuPages.Add((int)MenuItemType.Suplements, (NavigationPage)Detail);

            Detail = new NavigationPage(new SuplementListPage());
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Suplements:
                        MenuPages.Add(id, new NavigationPage(new SuplementListPage()));
                        break;
                    case (int)MenuItemType.Workouts:
                        MenuPages.Add(id, new NavigationPage(new WorkoutsPage()));
                        break;
                    case (int)MenuItemType.Memberships:
                        MenuPages.Add(id, new NavigationPage(new MembershipPage()));
                        break;
                    case (int)MenuItemType.WorkoutAdvice:
                        MenuPages.Add(id, new NavigationPage(new WorkoutAdvicePage()));
                        break;
                    case (int)MenuItemType.WorkoutAdviceTrainer:
                        MenuPages.Add(id, new NavigationPage(new WorkoutAdviceTrainerPage()));
                        break;
                    case (int)MenuItemType.LogOut:
                        MenuPages.Add(id, new NavigationPage(new LoginPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}