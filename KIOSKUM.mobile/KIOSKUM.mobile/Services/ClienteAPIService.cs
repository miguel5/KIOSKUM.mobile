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
        readonly List<Cliente> Clientes;
        private const string URL_auth = "https://kioskum.azurewebsites.net/api/cliente/login";
        private HttpClient _client = new HttpClient();

        public ClienteAPIService()
        {

        }

        public async Task<IEnumerable<Cliente>> GetItemsAsync(bool forceRefresh = false)
        {
            try
            {
                string url = "https://kioskum.azurewebsites.net/api/Produto/Todos";
                var response = await _client.GetStringAsync(url);
                var clientes = JsonConvert.DeserializeObject<List<Cliente>>(response);
                return clientes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> AddItemAsync(Cliente cliente)
        {
            Clientes.Add(cliente);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Cliente cliente)
        {

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {

            return await Task.FromResult(true);
        }


        public async Task<Tuple<Cliente,bool>> AuthenticateClient(string email, string password)
        {
            try
            {
                var cliente = new LoginPostModel { Email = email, Password = password };
                var content = JsonConvert.SerializeObject(cliente);

                var response = await _client.PostAsync(URL_auth, new StringContent(content, Encoding.UTF8, "application/json"));
                bool success = response.IsSuccessStatusCode;

                if (success)
                {
                    Cliente cli = JsonConvert.DeserializeObject<Cliente>(await response.Content.ReadAsStringAsync());
                    return new Tuple<Cliente,bool>(cli, success);
                }
                else
                {
                    return new Tuple<Cliente, bool>(new Cliente(), success);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }     
        }
    }
}
