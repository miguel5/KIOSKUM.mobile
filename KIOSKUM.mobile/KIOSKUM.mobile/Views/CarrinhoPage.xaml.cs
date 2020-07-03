using KIOSKUM.mobile.Models;
using KIOSKUM.mobile.ViewModels;
using KIOSKUM.mobile.CustomElements;
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
            //BindingContext = ViewModel;

        }

        /*
         * Comportamento apos o click do botao remover
         */
        public void RemoverClicked(Object sender, EventArgs args)
        {
            Button button = (Button)sender;
            CarrinhoItem itemToRemove = (CarrinhoItem)button.CommandParameter;

            ViewModel.Items.Remove(itemToRemove);
            ViewModel.updateTotal();
        }

        /*
         * Comportamento apos o click do botao pedir reserva
         */
        public void PedirReservaClicked(Object sender, EventArgs args)
        {
            Console.WriteLine(_timePicker.Time);

        }

        /*
         * Stepper handler
         */
        void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            /*Stepper stepper = (Stepper)sender;
            StackLayout stack = (StackLayout)stepper.Parent;
            stack.

            CarrinhoItem itemToRemove = (CarrinhoItem)stepper.BindingContext

            double value = e.NewValue;
            _rotatingLabel.Rotation = value;
            _displayLabel.Text = string.Format("The Stepper value is {0}", value);

            <Stepper x:Name="stepper" Maximum="99"
                                             ValueChanged="OnStepperValueChanged"
                                             Value="{Binding Qtd, Mode=TwoWay}" />
           <Label x:Name="quantidade_label" BindingContext="{x:Reference stepper}" Text="{Binding Value}"/>


            */
        }


        /*
         * Comportamento apos um click sobre um produto
         */
        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }


        void OnStepperClicked(object sender, EventArgs e)
        {
            ViewModel.updateTotal();
        }
    }
}