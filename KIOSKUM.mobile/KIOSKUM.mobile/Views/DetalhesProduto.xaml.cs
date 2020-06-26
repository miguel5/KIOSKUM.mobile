using KIOSKUM.mobile.Models;
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
    public partial class DetalhesProduto : ContentPage
    {
        public DetalhesProdutoViewModel ViewModel { get; set; }
        
        public string IngredientesString { get; set; }

        public DetalhesProduto(DetalhesProdutoViewModel viewModel)
        {
            this.ViewModel = viewModel;

            IngredientesString = string.Join(", ", ViewModel.Produto.Ingredientes.ToArray());

            BindingContext = ViewModel;

            InitializeComponent();

            Title = ViewModel.Produto.Nome;
        }
    }
}