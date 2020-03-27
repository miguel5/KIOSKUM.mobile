using KIOSKUM.mobile.PostModels;
using KIOSKUM.mobile.Services;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KIOSKUM.mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        readonly ClienteAPIService API = new ClienteAPIService();
        public CriarContaPostModel Conta { get; set; }
        public SignUpPage()
        {
            InitializeComponent();
            this.Conta = new CriarContaPostModel();

            BindingContext = this;
        }

        async void Register_Clicked(object sender, EventArgs e)
        {
            var response = await API.CriarConta(Conta.Nome, Conta.Email, Conta.NumTelemovel, Conta.Password);

            if (response.IsSuccessStatusCode)
            {
                invalidinfo_label.IsVisible = false;
                await Navigation.PushModalAsync(new InsertCodePage(), false);
            }

            else if ((int) response.StatusCode == 400)
            {
                invalidinfo_label.Text = "Campos de preenchimento obrigatório!";
                invalidinfo_label.IsVisible = true;
            }

            else if ((int)response.StatusCode == 409)
            {
                if (response.Content.ReadAsStringAsync().Result.Equals("TelemovelRepetido (Parameter 'NumTelemovel')"))
                {
                    invalidinfo_label.Text = "Número de telemóvel já registado!";
                }
                else if (response.Content.ReadAsStringAsync().Result.Equals("EmailRepetido (Parameter 'Email')"))
                {
                    invalidinfo_label.Text = "Email já registado!";
                }
                else
                {
                    invalidinfo_label.Text = "409 Conflict";
                }
                    
                invalidinfo_label.IsVisible = true;
            }

            else
            {
                invalidinfo_label.Text = "Erro no servidor!";
                invalidinfo_label.IsVisible = true;
            }

            //  DEBUG
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
        }
    }
}