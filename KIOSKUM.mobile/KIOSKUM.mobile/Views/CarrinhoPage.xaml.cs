using KIOSKUM.mobile.Models;
using KIOSKUM.mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KIOSKUM.mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarrinhoPage : ContentPage
    {
        public CarrinhoViewModel ViewModel { get; set; }

        public CarrinhoPage(CarrinhoViewModel viewModel)
        {
            InitializeComponent();
            Title = "Carrinho";

            BindingContext = this.ViewModel = viewModel;
            BindingContext = ViewModel;
        }
    }
}