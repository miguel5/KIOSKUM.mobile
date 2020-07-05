using KIOSKUM.mobile.ViewModels;
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
    public partial class InsertCodePage : ContentPage
    {
        InsertCodeViewModel ViewModel;

        public InsertCodePage(InsertCodeViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;

            BindingContext = ViewModel;
        }

        public void Register_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "InsertCodeRegisterClicked");

            //await Navigation.PopModalAsync();
            //Content = new AboutPage().Content;
            //App.Current.MainPage = new LoginPage();
        }
    }
}