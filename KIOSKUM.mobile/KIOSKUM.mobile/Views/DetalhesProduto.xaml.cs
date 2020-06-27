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
        public CarrinhoViewModel CarrinhoVM { get; set; }
        
        public static string IngredientesString { get; set; }

        public DetalhesProduto(DetalhesProdutoViewModel viewModel, CarrinhoViewModel carrinhoVM)
        {
            this.ViewModel = viewModel;
            this.CarrinhoVM = carrinhoVM;

            IngredientesString = string.Join(", ", ViewModel.Produto.Ingredientes.ToArray());

            BindingContext = ViewModel;

            InitializeComponent();

            Title = ViewModel.Produto.Nome;
        }

        /*
         * Comportamento apos o botao de adicionar produto ser clicado
         */
        public void AddProdClicked(Object sender, EventArgs args)
        {
            this.CarrinhoVM.Items.Add(new CarrinhoItem { Id = ViewModel.Produto.Nome, Obs = this.ViewModel.Observacoes, Qtd = 1 });
            Navigation.PopModalAsync();
        }
    }
}