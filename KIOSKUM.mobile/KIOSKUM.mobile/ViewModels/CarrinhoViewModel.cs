using KIOSKUM.mobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace KIOSKUM.mobile.ViewModels
{
    public class CarrinhoViewModel : BaseViewModel
    {
        private double _total;

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
            //Items.Add(new CarrinhoItem { Id = "Baguete de Atum", Qtd = 1, Obs = "Sem tomate" });
            //Items.Add(new CarrinhoItem { Id = "Água 50cl", Qtd = 1, Obs = "Natural" });

            Carrinho = new Carrinho { Items = Items };
            updateTotal();
            selectedTime = new TimeSpan(0, 0, 0);
        }

        public void updateTotal()
        {
            //Total = Items.Sum(x => x.PrecoTotal);
            OnPropertyChanged("Total");
        }

    }
}
