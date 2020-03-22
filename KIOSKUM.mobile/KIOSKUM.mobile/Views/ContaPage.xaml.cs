using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KIOSKUM.mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContaPage : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public ContaPage()
        {
            InitializeComponent();
            Title = "Conta";

            Items = new ObservableCollection<string>
            {
                "Histórico de Reservas",
                "Editar Conta",
                "Logout"
            };

            MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

           // await DisplayAlert("Item Tapped", e.Item.GetType().ToString() + "\n" + e.Item.ToString(), "OK");
           if(e.Item.ToString().Equals("Editar Conta"))
                await Navigation.PushAsync(new EditarContaPage());

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
