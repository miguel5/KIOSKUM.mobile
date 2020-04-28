using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using KIOSKUM.mobile.Services;
using KIOSKUM.mobile.Models;
using KIOSKUM.mobile.ViewModels;
using System.Collections.ObjectModel;

namespace KIOSKUM.mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProdutosPage : ContentPage
    {
        public IEnumerable<Produto> Items { get; set; }
        public ProdutosPage()
        {
            InitializeComponent();
            Title = "Produtos";
            AtualizaDados();
        }
        private void AtualizaDados()
        {
            //items = await service.GetItemsAsync();

            // Teste
            // -----------------------
            var produtos = new ObservableCollection<Produto>
                {
                    new Produto(1, "Tosta Mista", "Sandes", 2.50, new List<string>{"queijo", "fiambre", "pão"}, new List<string>(), ""),
                    new Produto(2, "Água 50cl", "Bebidas", 0.80, new List<string>(), new List<string>(), ""),
                    new Produto(2, "Coca-Cola 33cl", "Bebidas", 1.20, new List<string>(), new List<string>(), ""),
                    new Produto(3, "Baguete de Atum", "Sandes", 3.50, new List<string>(), new List<string>(), ""),
                    new Produto(3, "Sandes de Panado", "Sandes", 3.50, new List<string>(), new List<string>(), ""),
                    new Produto(3, "Pizza de Fiambre", "Pizzas", 2.50, new List<string>(), new List<string>(), "")
                };
            Items = produtos;
            // ---------------------

            produtoLista.ItemsSource = Listar();
        }
        private void Procurar_TextChanged(object sender, TextChangedEventArgs e)
        {
            produtoLista.ItemsSource = this.Listar(this.sbProcurar.Text);
        }

        public IEnumerable<ProdutosViewModel<string, Produto>> Listar(string filtro = "")
        {
            IEnumerable<Produto> produtosFiltrados = Items;

            if (!string.IsNullOrEmpty(filtro))
                produtosFiltrados = Items.Where(l => (l.Nome.ToLower().Contains(filtro.ToLower()))
                                                        || l.NomeCategoria.ToLower().Contains(filtro.ToLower()));
            return from produto in produtosFiltrados
                   orderby produto.Nome
                   group produto by produto.NomeCategoria into grupos
                   select new ProdutosViewModel<string, Produto>(grupos.Key, grupos);
        }

        async void Carrinho_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new CarrinhoPage()));
        }
    }
}