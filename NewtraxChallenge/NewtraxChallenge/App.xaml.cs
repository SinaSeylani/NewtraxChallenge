using System;
using NewtraxChallenge.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewtraxChallenge
{
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new WorkerListView());
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

