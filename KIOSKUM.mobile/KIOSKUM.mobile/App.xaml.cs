using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using KIOSKUM.mobile.Services;
using KIOSKUM.mobile.Views;

namespace KIOSKUM.mobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
