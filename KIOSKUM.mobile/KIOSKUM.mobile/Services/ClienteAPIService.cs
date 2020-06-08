using KIOSKUM.mobile.Models;
using KIOSKUM.mobile.PostModels;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace KIOSKUM.mobile.Services
{
    public class ClienteAPIService
    {
        private const string URL_auth = "https://kioskum.azurewebsites.net/api/cliente/login";
        private const string URL_criar = "https://kioskum.azurewebsites.net/api/cliente/criar";
        private const string URL_confirmar = "https://kioskum.azurewebsites.net/api/cliente/confirmar";
        private const string URL_getCliente = "https://kioskum.azurewebsites.net/api/cliente/get";
        private HttpClient _client = new HttpClient();

        public ClienteAPIService()
        {

        }

        public async Task<ErrorsList> CriarConta(CriarContaPostModel conta)
        {
            try
            {
                var content = JsonConvert.SerializeObject(conta);

                var response = await _client.PostAsync(URL_criar, new StringContent(content, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    return new ErrorsList();
                }
                if(response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    var erros = new ErrorsList();
                    erros.ListaErros.Add(21);      // Adiciona erro 21 Erro do lado do servidor
                    return erros;
                }
                else
                {
                    var erros = JsonConvert.DeserializeObject<ErrorsList>(response.Content.ReadAsStringAsync().Result);

                    if (!erros.ListaErros.Any())
                    {
                        erros.ListaErros.Add(20); // Adiciona erro 20 Campos de Preenchimento Obrigatorio
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
    


        public async Task<bool> AuthenticateClient(LoginPostModel cliente)
        {
            try
            {
                var content = JsonConvert.SerializeObject(cliente);

                var response = await _client.PostAsync(URL_auth, new StringContent(content, Encoding.UTF8, "application/json"));
                bool success = response.IsSuccessStatusCode;
                App.AuthToken = JsonConvert.DeserializeObject<AuthToken>(response.Content.ReadAsStringAsync().Result);   // set auth token

                return success;
            }
            catch (Exception ex)
            {
                throw ex;
            }     
        }

        public async Task<bool> ValidateAccount(ValidarContaPostModel codigo)
        {
            try
            {
                var content = JsonConvert.SerializeObject(codigo);

                var response = await _client.PostAsync(URL_confirmar, new StringContent(content, Encoding.UTF8, "application/json"));
                bool success = response.IsSuccessStatusCode;

                return success;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Cliente> GetCliente()
        {
            try
            {
                _client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", App.AuthToken.Token);

                var response = await _client.GetAsync(URL_getCliente);
                bool success = response.IsSuccessStatusCode;

                Console.WriteLine("Resposta: " + response.Content.ReadAsStringAsync().Result);

                if (!success)
                    return new Cliente();

                var cliente = JsonConvert.DeserializeObject<Cliente>(response.Content.ReadAsStringAsync().Result);              

                return cliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
