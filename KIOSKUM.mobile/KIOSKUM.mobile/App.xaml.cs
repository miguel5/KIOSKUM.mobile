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
            //MainPage = new NavigationPage(new CarrinhoPage());  // DEBUG
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
