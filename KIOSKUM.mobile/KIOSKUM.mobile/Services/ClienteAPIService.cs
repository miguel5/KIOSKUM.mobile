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
    class ClienteAPIService
    {
        private const string URL_auth = "https://kioskum.azurewebsites.net/api/cliente/login";
        private const string URL_criar = "https://kioskum.azurewebsites.net/api/cliente/criar";
        private HttpClient _client = new HttpClient();

        public ClienteAPIService()
        {

        }

        public async Task<HttpResponseMessage> CriarConta(string nome, string email, string telemovel, string password)
        {
            try
            {
                var conta = new CriarContaPostModel { Nome = nome, Email = email, NumTelemovel = telemovel, Password = password };
                var content = JsonConvert.SerializeObject(conta);
                
                var response = await _client.PostAsync(URL_criar, new StringContent(content, Encoding.UTF8, "application/json"));
                bool success = response.IsSuccessStatusCode;

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    


        public async Task<bool> AuthenticateClient(string email, string password)
        {
            try
            {
                var cliente = new LoginPostModel { Email = email, Password = password };
                var content = JsonConvert.SerializeObject(cliente);

                var response = await _client.PostAsync(URL_auth, new StringContent(content, Encoding.UTF8, "application/json"));
                bool success = response.IsSuccessStatusCode;

                //Cliente cli = JsonConvert.DeserializeObject<Cliente>(await response.Content.ReadAsStringAsync());
                return success;
            }
            catch (Exception ex)
            {
                throw ex;
            }     
        }
    }
}
