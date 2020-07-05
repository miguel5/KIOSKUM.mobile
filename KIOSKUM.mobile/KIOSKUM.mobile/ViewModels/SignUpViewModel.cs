using KIOSKUM.mobile.Services;
using KIOSKUM.mobile.Models;
using System.Collections.Generic;
using KIOSKUM.mobile.PostModels;
using KIOSKUM.mobile.Views;
using Xamarin.Forms;
using System;
using System.Linq;

namespace KIOSKUM.mobile.ViewModels
{
    class SignUpViewModel : BaseViewModel
    {
        public ClienteAPIService API { get; set; }
        public CriarContaPostModel Conta { get; set; }

        private List<string> _erros;
        public List<string> Erros
        {
            get { return _erros; }
            set { _erros = value; OnPropertyChanged(); }
        }

        public SignUpViewModel()
        {
            API = new ClienteAPIService();
            Conta = new CriarContaPostModel();
            Erros = new List<string>();

            MessagingCenter.Subscribe<SignUpPage>(this, "SignUpRegisterClicked", async (page) =>
            {
                var erros = await API.CriarConta(Conta);
                List<string> errosStr = new List<string>();

                if (!erros.Erros.Any())
                {
                    var viewModel = new InsertCodeViewModel();
                    viewModel.ValidarConta = new ValidarContaPostModel { Email = Conta.Email };
                    var validarConta = new ValidarContaPostModel { Email = Conta.Email };
                    await page.Navigation.PushModalAsync(new InsertCodePage(new InsertCodeViewModel {ValidarConta = validarConta }));
                }

                else
                {
                    foreach (int erro in erros.Erros)
                    {
                        errosStr.Add(ErrorMessages._messages[erro]);
                    }
                }
                Erros = errosStr;
                //page.ErrorsList.ItemsSource = Erros;
            });

        }
    }
}
