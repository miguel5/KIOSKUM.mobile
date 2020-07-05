using KIOSKUM.mobile.PostModels;
using KIOSKUM.mobile.Services;
using KIOSKUM.mobile.Views;
using Xamarin.Forms;

namespace KIOSKUM.mobile.ViewModels
{
    public class InsertCodeViewModel
    {
        public ValidarContaPostModel ValidarConta { get; set; }
        public ClienteAPIService API { get; set; }
        public bool LabelVisible { get; set; }

        public InsertCodeViewModel()
        {
            API = new ClienteAPIService();
            LabelVisible = false;
            
            MessagingCenter.Subscribe<InsertCodePage>(this, "InsertCodeRegisterClicked", async (page) =>
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
            });
        }
    }
}
