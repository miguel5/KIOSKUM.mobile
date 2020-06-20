using KIOSKUM.mobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace KIOSKUM.mobile.ViewModels
{
    public class CarrinhoViewModel : BaseViewModel
    {
        public Carrinho Carrinho { get; set; }
        public ObservableCollection<CarrinhoItem> Items { get; set; }
        public TimeSpan selectedTime;

        public CarrinhoViewModel()
        {
            Items = new ObservableCollection<CarrinhoItem>();
            //Items.Add(new CarrinhoItem { Id = "Baguete de Atum", Qtd = 1, Obs = "Sem tomate" });
            //Items.Add(new CarrinhoItem { Id = "Água 50cl", Qtd = 1, Obs = "Natural" });

            Carrinho = new Carrinho { Items = Items };
            selectedTime = new TimeSpan(0, 0, 0);
        }

    }
}
