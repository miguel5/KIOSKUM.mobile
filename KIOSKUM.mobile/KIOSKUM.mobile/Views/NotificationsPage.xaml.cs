using KIOSKUM.mobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KIOSKUM.mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificationsPage : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public NotificationsPage()
        {
            InitializeComponent();
            Title = "Notificações";

            // Debug
            /*
            var api = new Services.APIService();
            var produtos = api.GetProdutosAsync();

            IList<string> Items = new List<string>();
            foreach (var produto in produtos.Result)
            {
                Items.Add(produto.ToString());
            }*/

            
            Items = new ObservableCollection<string>
            {
                "05/03/2020 10:33:00 - Reserva Aceite",
                "05/03/2020 10:30:00 - Reserva Rejeitada",
                "05/03/2020 09:46:00 - Reserva Aceite"
            };

            MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
