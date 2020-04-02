using KIOSKUM.mobile.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KIOSKUM.mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        SignUpViewModel ViewModel { get; set; }
        public SignUpPage()
        {
            InitializeComponent();
            
            ViewModel = new SignUpViewModel();

            BindingContext = ViewModel;
        }

        public void Register_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "SignUpRegisterClicked");

        }
    }
}