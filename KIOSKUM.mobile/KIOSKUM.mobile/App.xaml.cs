using Xamarin.Forms;
using KIOSKUM.mobile.Services;
using KIOSKUM.mobile.Views;
using KIOSKUM.mobile.Models;

namespace KIOSKUM.mobile
{
    public partial class App : Application
    {
        public static Cliente Cliente { get; set; }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new LoginPage();                          // DEBUG
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
