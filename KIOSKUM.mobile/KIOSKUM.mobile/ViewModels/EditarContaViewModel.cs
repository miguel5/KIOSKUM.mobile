using KIOSKUM.mobile.Models;
using KIOSKUM.mobile.PostModels;
using KIOSKUM.mobile.Services;
using KIOSKUM.mobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KIOSKUM.mobile.ViewModels
{
    class EditarContaViewModel : BaseViewModel
    {
        public EditarContaPostModel EditarConta { get; set; }
        public Cliente Cliente { get; set; }
        public ClienteAPIService API { get; set; }

        public EditarContaViewModel()
        {
            API = new ClienteAPIService();

            Cliente = new Cliente();
            //Console.WriteLine("Yeeet: " + Cliente.Email);

            /*
            MessagingCenter.Subscribe<EditarContaPage>(this, "InsertCodeRegisterClicked", async (page) =>
            {
                var success = await API.ValidateAccount(ValidarConta);

                if (success)
                {
                    App.Current.MainPage = new LoginPage();
                }
                else
                {
                    LabelVisible = true;
                }
            });*/
        }

        public async void FetchData()
        {
            var cliente = await API.GetCliente();
            Cliente = cliente;
        }
    }
}
