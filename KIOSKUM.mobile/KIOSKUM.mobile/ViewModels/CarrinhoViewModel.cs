using KIOSKUM.mobile.Models;
using KIOSKUM.mobile.PostModels;
using KIOSKUM.mobile.Services;
using KIOSKUM.mobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace KIOSKUM.mobile.ViewModels
{
    public class CarrinhoViewModel : BaseViewModel
    {
        private double _total;
        private ReservaAPIService API { get; set; }

        public Carrinho Carrinho { get; set; }
        public ObservableCollection<CarrinhoItem> Items { get; set; }
        public double Total
        {
            get { return Items.Sum(x => x.PrecoTotal); }
            set {
                _total = value;
                OnPropertyChanged("Total");
            }
        }
        public TimeSpan selectedTime;


        public CarrinhoViewModel()
        {
            Items = new ObservableCollection<CarrinhoItem>();
            Carrinho = new Carrinho { Items = Items };
            selectedTime = new TimeSpan(0, 0, 0);
            API = new ReservaAPIService();

            UpdateTotal();

            MessagingCenter.Subscribe<CarrinhoPage>(this, "ConfirmarReservaClicked", async (page) =>
            {
                ReservaPostModel reserva = new ReservaPostModel(Items, selectedTime);
                
                var success = await API.RegistarReserva(reserva);

                // Verifica se a lista de erros está vazia
                if (!success.Erros.Any())
                {
                    page.DisplayReservaSucesso();
                    Items = new ObservableCollection<CarrinhoItem>();
                    Carrinho.Items = Items;
                }
                else
                {
                    page.DisplayErroRegistarReserva();
                }
            });
        }

        public void UpdateTotal()
        {
            OnPropertyChanged("Total");
        }

    }
}
