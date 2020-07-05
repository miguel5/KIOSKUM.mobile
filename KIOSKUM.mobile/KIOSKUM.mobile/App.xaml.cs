using Xamarin.Forms;
using KIOSKUM.mobile.Services;
using KIOSKUM.mobile.Views;
using KIOSKUM.mobile.Models;

namespace KIOSKUM.mobile
{
    public partial class App : Application
    {
        public static AuthToken AuthToken { get; set; }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new LoginPage();

            AuthToken = new AuthToken{Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIxIiwicm9sZSI6IkNsaWVudGUiLCJuYmYiOjE1OTM5MDIyN" +
                                              "jgsImV4cCI6MTU5NDUwNzA2OCwiaWF0IjoxNTkzOTAyMjY4fQ.PhGr9E9YpGJ9nEJpZe_sw6QVX2GIfy4-2ovr5BsfwCQ" };

            //MainPage = new NavigationPage(new ProdutosPage());  // DEBUG
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
