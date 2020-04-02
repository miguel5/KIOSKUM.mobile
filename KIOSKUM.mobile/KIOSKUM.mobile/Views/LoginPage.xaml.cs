using KIOSKUM.mobile.Models;
using KIOSKUM.mobile.PostModels;
using KIOSKUM.mobile.Services;
using KIOSKUM.mobile.ViewModels;
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
        LoginViewModel ViewModel;
        public LoginPage()
        {
            InitializeComponent();

            ViewModel = new LoginViewModel();

            BindingContext = ViewModel;
        }

        async void Register_Clicked(object sender, System.EventArgs e)
        {
            //Application.Current.MainPage =  new NavigationPage(new SignUpPage());
            await Navigation.PushModalAsync(new SignUpPage());
        }

        public void Login_Clicked(object sender, System.EventArgs e)
        {
            MessagingCenter.Send(this, "LoginClicked");
        }
    }
}