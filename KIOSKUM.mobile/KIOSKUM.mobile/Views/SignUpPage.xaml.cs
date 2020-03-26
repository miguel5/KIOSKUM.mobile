﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KIOSKUM.mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        async void Register_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PopModalAsync();
            //Content = new InsertCodePage().Content;
            await Navigation.PushModalAsync(new InsertCodePage(), false);
        }
    }
}