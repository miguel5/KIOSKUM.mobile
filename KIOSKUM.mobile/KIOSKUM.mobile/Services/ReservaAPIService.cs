using KIOSKUM.mobile.Models;
using KIOSKUM.mobile.PostModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

        public async Task<ErrorsList> RegistarReserva(ReservaPostModel reserva)
        {
            try
            {
                _client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", App.AuthToken.Token);

                var content = JsonConvert.SerializeObject(reserva);
                var response = await _client.PostAsync(URL_reserva, new StringContent(content, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    return new ErrorsList();
                }
                if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    var erros = new ErrorsList();
                    erros.Erros.Add(21);      // Adiciona erro 21 Erro do lado do servidor
                    return erros;
                }
                else
                {
                    var erros = JsonConvert.DeserializeObject<ErrorsList>(response.Content.ReadAsStringAsync().Result);
                    /*
                    if (!erros.Erros.Any())
                    {
                        // TODO: Alterar o código de erro
                        // Adiciona erro 20 Campos de Preenchimento Obrigatorio
                        erros.Erros.Add(20);
                    }*/
                    foreach(int e in erros.Erros)
                    {
                        Console.WriteLine("[ERRO] " + e);
                    }

                    return erros;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw ex;
            }
        }
    }
}
