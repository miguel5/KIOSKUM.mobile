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
        public InsertCodePage()
        {
            InitializeComponent();
        }

        public void Register_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PopModalAsync();
            //Content = new AboutPage().Content;
            App.Current.MainPage = new LoginPage();
        }
    }
}