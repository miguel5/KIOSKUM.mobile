using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace KIOSKUM.mobile.Models
{
    public class Carrinho
    {
        public ObservableCollection<CarrinhoItem> Items { get; set; }
    }
}
