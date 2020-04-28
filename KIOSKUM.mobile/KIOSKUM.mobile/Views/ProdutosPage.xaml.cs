﻿using System;
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
        ProdutoAPIService service;
        IEnumerable<Produto> items;
        public ProdutosPage()
        {
            InitializeComponent();
            Title = "Produtos";
            service = new ProdutoAPIService();
            AtualizaDados();
        }
        private void AtualizaDados()
        {
            //items = await service.GetItemsAsync();

            // Teste
            // -----------------------
            var produtos = new ObservableCollection<Produto>
                {
                    new Produto(1, "Tosta Mista", "Sandes", 2.00, new List<string>{"queijo", "fiambre", "pão"}, new List<string>(), ""),
                    new Produto(2, "Água 50cl", "Bebidas", 1.00, new List<string>(), new List<string>(), "")
                };
            items = produtos;
            // ---------------------

            produtoLista.ItemsSource = Listar();
        }
        private void Procurar_TextChanged(object sender, TextChangedEventArgs e)
        {
            produtoLista.ItemsSource = this.Listar(this.sbProcurar.Text);
        }

        public IEnumerable<ProdutosViewModel<string, Produto>> Listar(string filtro = "")
        {
            IEnumerable<Produto> produtosFiltrados = this.items;

            if (!string.IsNullOrEmpty(filtro))
                produtosFiltrados = items.Where(l => (l.Nome.ToLower().Contains(filtro.ToLower()))
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