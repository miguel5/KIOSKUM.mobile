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
    public class ClienteAPIService
    {
        private const string URL_auth = "https://kioskum.azurewebsites.net/api/cliente/login";
        private const string URL_criar = "https://kioskum.azurewebsites.net/api/cliente/criar";
        private const string URL_confirmar = "https://kioskum.azurewebsites.net/api/cliente/confirmar";
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
    }
}
