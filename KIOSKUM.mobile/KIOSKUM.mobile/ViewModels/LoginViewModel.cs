using KIOSKUM.mobile.PostModels;
using KIOSKUM.mobile.Services;
using KIOSKUM.mobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace KIOSKUM.mobile.ViewModels
{
    class LoginViewModel
    {
        public ClienteAPIService API { get; set; }
        public LoginPostModel Login { get; set; }

        public LoginViewModel()
        {
            API = new ClienteAPIService();
            Login = new LoginPostModel();

            MessagingCenter.Subscribe<LoginPage>(this, "LoginClicked", async (page) =>
            {
                //var erros = await API.AuthenticateClient();
                
            });
        }
    }
}