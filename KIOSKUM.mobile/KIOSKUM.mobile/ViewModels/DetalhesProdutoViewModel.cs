using KIOSKUM.mobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KIOSKUM.mobile.ViewModels
{
    public class DetalhesProdutoViewModel : BaseViewModel
    {
        public Produto Produto { get; set; }
        public string Observacoes { get; set; }

        public DetalhesProdutoViewModel() { 
        
        }
    }
}
