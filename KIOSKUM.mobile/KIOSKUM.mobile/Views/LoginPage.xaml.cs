using KIOSKUM.mobile.Models;
using KIOSKUM.mobile.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KIOSKUM.mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        readonly ClienteAPIService API = new ClienteAPIService();
        public LoginPage()
        {
            InitializeComponent();

        }

        async void Register_Clicked(object sender, System.EventArgs e)
        {
            //Application.Current.MainPage =  new NavigationPage(new SignUpPage());
            await Navigation.PushModalAsync(new SignUpPage());
        }

        public void Login_Clicked(object sender, System.EventArgs e)
        {
            var email = email_entry.Text;
            var password = password_entry.Text;

            var success = API.AuthenticateClient(email, password).Result;

            // Login falhou
            if (!success)
            {
                badlogin_label.IsVisible = true;
                MainPage homePage = new MainPage();     // DEBUG
                App.Current.MainPage = homePage;
            }
            // Login bem sucedido
            else
            {
                badlogin_label.IsVisible = false;
                MainPage homePage = new MainPage();
                App.Current.MainPage = homePage;
            }
        }
    }
}