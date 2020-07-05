using KIOSKUM.mobile.Models;
using KIOSKUM.mobile.ViewModels;
using System;
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
        }

        /*
         * Comportamento apos o click do botao remover
         */
        public void RemoverClicked(Object sender, EventArgs args)
        {
            Button button = (Button)sender;
            CarrinhoItem itemToRemove = (CarrinhoItem)button.CommandParameter;

            ViewModel.Items.Remove(itemToRemove);
            ViewModel.UpdateTotal();
        }

        /*
         * Comportamento apos o click do botao pedir reserva
         */
        async public void OnConfirmarReservaClicked(Object sender, EventArgs args)
        {
            if (ViewModel.Total == 0)
                return;

            ViewModel.selectedTime = _timePicker.Time;

            object[] values = new object[] { ViewModel.Total, _timePicker.Time };
            string question = string.Format("Confirmar reserva no valor de {0:0.00} € para as {1:hh\\:mm} ?", values);

            bool answer = await DisplayAlert("Confirmar reserva", question, "Sim", "Não");

            if (answer)
            {
                MessagingCenter.Send(this, "ConfirmarReservaClicked");
            }
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
            ViewModel.UpdateTotal();
        }

        public async void DisplayErroRegistarReserva()
        {
            await DisplayAlert("Erro na operação", "Ocorreu um erro ao registar a reserva, tente mais tarde.", "OK");
        }

        public async void DisplayReservaSucesso()
        {
            await DisplayAlert("Pedido de reserva efetuado", "O seu pedido de reserva foi efetuado com sucesso e aguarda confirmação.", "OK");
            await Navigation.PopModalAsync();
        }
    }
}