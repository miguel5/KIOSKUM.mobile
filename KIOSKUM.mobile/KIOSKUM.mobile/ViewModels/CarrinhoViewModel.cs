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

        public CarrinhoViewModel()
        {
            Items = new ObservableCollection<CarrinhoItem>();
            Items.Add(new CarrinhoItem { Id = "Tosta Mista", Qtd = 1, Obs = "Sem queijo" });
            Items.Add(new CarrinhoItem { Id = "Tosta Mista", Qtd = 1, Obs = "Sem fiambre" });
            Items.Add(new CarrinhoItem { Id = "Água 50cl", Qtd = 2, Obs = "Natural" });

            Carrinho = new Carrinho { Items = Items };
        }
    }
}
