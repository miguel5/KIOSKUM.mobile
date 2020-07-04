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
            //MainPage = new LoginPage();

            AuthToken = new AuthToken{Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIzIiwicm9sZSI6IkNsaWVudGUiLCJuYmYiOjE1ODU3NTk1ND" +
                                      "IsImV4cCI6MTU4NjM2NDM0MiwiaWF0IjoxNTg1NzU5NTQyfQ.Q-mOzss5ez67kIWx7UTC4drCTwRL_LcEItm4SOwOMv8" };

            MainPage = new NavigationPage(new ProdutosPage());  // DEBUG
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
