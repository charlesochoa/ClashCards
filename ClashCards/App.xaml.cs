using System;
using ClashCards.Services;
using ClashCards.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClashCards
{
    public partial class App : Application
    {
        public static ClashCardsManager CardsManager { get; private set; }

        public App()
        {
            InitializeComponent();
            CardsManager = new ClashCardsManager(new CardsService());
            var mainPage = new NavigationPage(new ClashCardsListViewPage());
            MainPage = mainPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
