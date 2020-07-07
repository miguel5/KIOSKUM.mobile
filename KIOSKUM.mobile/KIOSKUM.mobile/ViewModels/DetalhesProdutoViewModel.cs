using KIOSKUM.mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KIOSKUM.mobile.ViewModels
{
    public class DetalhesProdutoViewModel : BaseViewModel
    {
        public Produto Produto { get; set; }
        public string Observacoes { get; set; }
        public string AlergeniosString { get; set; }
        public string IngredientesString { get; set; }

        public DetalhesProdutoViewModel(Produto produto) 
        {
            Produto = produto;
            IngredientesString = string.Join(", ", Produto.Ingredientes.ToArray());
            AlergeniosString = string.Join(", ", Produto.Alergenios.ToArray());
        }
    }
}
