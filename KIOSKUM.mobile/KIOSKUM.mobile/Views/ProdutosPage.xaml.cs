﻿using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using KIOSKUM.mobile.Services;
using KIOSKUM.mobile.Models;
using KIOSKUM.mobile.ViewModels;

namespace KIOSKUM.mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProdutosPage : ContentPage
    {
        public IEnumerable<Produto> Items { get; set; }
        public CarrinhoViewModel CarrinhoVM { get; set; }
        private ProdutoAPIService API;

        public ProdutosPage()
        {
            InitializeComponent();
            Title = "Produtos";
            this.CarrinhoVM = new CarrinhoViewModel();
            API = new ProdutoAPIService();
            AtualizaDados();
        }


        async private void AtualizaDados()
        {
            Items = await API.GetItemsAsync();
            //Console.WriteLine(Items.ToList()[0].ToString());

            // Teste
            // -----------------------
            /*
            var produtos = new ObservableCollection<Produto>
                {
                    new Produto(1, "Tosta Mista", "Sandes", 2.50, new List<string>{"queijo", "fiambre", "pão"}, new List<string>(), ""),
                    new Produto(2, "Água 50cl", "Bebidas", 0.80, new List<string>(), new List<string>(), ""),
                    new Produto(2, "Coca-Cola 33cl", "Bebidas", 1.20, new List<string>(), new List<string>(), ""),
                    new Produto(3, "Baguete de Atum", "Sandes", 3.50, new List<string>(), new List<string>(), "https://kioskum.azurewebsites.net/images/produto/Baguete_de_Atum.png"),
                    new Produto(3, "Sandes de Panado", "Sandes", 3.50, new List<string>(), new List<string>(), ""),
                    new Produto(3, "Pizza de Fiambre", "Pizzas", 2.50, new List<string>(), new List<string>(), "")
                };
            Items = produtos;
            */
            // ---------------------

            produtoLista.ItemsSource = Listar();
        }

        /*
         * Quando o campo de texto de procurar um produto for alterado chama o
         * método Listar para atualizar os produtos mostrados
         */
        private void Procurar_TextChanged(object sender, TextChangedEventArgs e)
        {
            produtoLista.ItemsSource = this.Listar(this.sbProcurar.Text);
        }

        /*
         * Listar produtos de acordo com um filtro
         */
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

        /*
         * Comportamento apos um click sobre o carrinho
         */
        async void Carrinho_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new CarrinhoPage (this.CarrinhoVM)));
        }

        /*
         * Comportamento apos um click sobre um produto
         */
        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            var selectedProduct = e.Item as Produto;

            await Navigation.PushModalAsync(new NavigationPage(new DetalhesProduto(new DetalhesProdutoViewModel { Produto = selectedProduct }, this.CarrinhoVM)));

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        /*
         * Comportamento apos o botao de adicionar produto ser clicado
         */
        public void AddProdClicked(Object sender, EventArgs args)
        {
            Button button = (Button)sender;
            Produto produto = (Produto)button.CommandParameter;

            this.CarrinhoVM.Items.Add(new CarrinhoItem { Id = produto.IdProduto, Nome = produto.Nome, Obs = null, Qtd = 1, PrecoUnidade = produto.Preco });
        }
    }
}