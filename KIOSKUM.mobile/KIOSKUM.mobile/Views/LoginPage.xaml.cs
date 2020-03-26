﻿using KIOSKUM.mobile.Models;
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

        public async void Login_Clicked(object sender, System.EventArgs e)
        {
            //Application.Current.MainPage = new MainPage();            // DEBUG
            var email = email_entry.Text;
            var password = password_entry.Text;

            //Cliente cli =  await API.AuthenticateClient("lazaro.pinheiro1998@gmail.com", "123456");
            //Cliente cli = await API.AuthenticateClient(email, password);
            Tuple<Cliente,bool> resp = await API.AuthenticateClient(email, password);
            var cli = resp.Item1;
            var success = resp.Item2;

            // Login falhou
            if (!success)
            {
                badlogin_label.IsVisible = true;
                MainPage homePage = new MainPage();     // DEBUG
                //App.Current.MainPage = homePage;
            }
            // Login bem sucedido
            else
            {
                badlogin_label.IsVisible = false;
                App.Cliente = cli;
                MainPage homePage = new MainPage();
                App.Current.MainPage = homePage;
            }
        }
    }
}