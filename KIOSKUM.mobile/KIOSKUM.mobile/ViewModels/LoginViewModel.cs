using KIOSKUM.mobile.PostModels;
using KIOSKUM.mobile.Services;
using KIOSKUM.mobile.Views;
using Xamarin.Forms;

namespace KIOSKUM.mobile.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        public ClienteAPIService API { get; set; }
        private LoginPostModel _login;
        public LoginPostModel Login
        {
            get { return _login; }
            set { _login = value; OnPropertyChanged(); }
        }

        private bool _labelVisible;
        public bool LabelVisible
        {
            get { return _labelVisible; }
            set { _labelVisible = value; OnPropertyChanged(); }
        }


        public LoginViewModel()
        {
            API = new ClienteAPIService();
            Login = new LoginPostModel();
            LabelVisible = false;

            MessagingCenter.Subscribe<LoginPage>(this, "LoginClicked", async (page) =>
            {
                var success = await API.AuthenticateClient(Login);

                // Login falhou
                if (!success)
                {
                    LabelVisible = true;
                    //MainPage homePage = new MainPage();     // DEBUG
                    //App.Current.MainPage = homePage;
                }
                // Login bem sucedido
                else
                {
                    LabelVisible = false;
                    MainPage homePage = new MainPage();
                    App.Current.MainPage = homePage;
                }

            });
        }
    }
}