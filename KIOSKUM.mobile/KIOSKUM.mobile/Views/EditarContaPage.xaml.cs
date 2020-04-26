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
    public partial class EditarContaPage : ContentPage
    {
        EditarContaViewModel ViewModel { get; set; }

        public EditarContaPage()
        {
            ViewModel = new EditarContaViewModel();
            //ViewModel.FetchData();
            BindingContext = ViewModel;

            InitializeComponent();
        }

        async void Guardar_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Guardar Alterações", "Tem a certeza que deseja guardar as alterações?", "OK");
        }
    }
}