using KIOSKUM.mobile.Models;
using KIOSKUM.mobile.PostModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KIOSKUM.mobile.Services
{
    class ReservaAPIService
    {
        private const string URL_reserva = "https://kioskum.azurewebsites.net/api/reserva/registar";
        private HttpClient _client = new HttpClient();

        public ReservaAPIService()
        {

        }

        public async Task<bool> RegistarReserva(ReservaPostModel reserva)
        {
            try
            {
                var content = JsonConvert.SerializeObject(reserva);
                var response = await _client.PostAsync(URL_reserva, new StringContent(content, Encoding.UTF8, "application/json"));

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw ex;
            }
        }
    }
}
