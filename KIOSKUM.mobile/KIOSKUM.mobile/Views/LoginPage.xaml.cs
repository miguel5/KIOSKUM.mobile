using KIOSKUM.mobile.Services;
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
            //Application.Current.MainPage = new MainPage();
            //var text = email_entry.T
        }
    }
}