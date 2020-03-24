using KIOSKUM.mobile.Models;
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
        private const string URL_auth = "http://kioskum.azurewebsites.net/api/cliente/autenticacao";
        private HttpClient _client = new HttpClient();

        public ClienteAPIService()
        {
            Clientes = this.GetItemsAsync().Result.ToList();
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


        public async Task<Cliente> AuthenticateClient(string email, string password)
        {
            var cliente = new Cliente { Email = email, Password = password };
            var content = JsonConvert.SerializeObject(cliente);
            var response = await _client.PostAsync(URL_auth, new StringContent(content, Encoding.UTF8, "application/json"));
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);

            return JsonConvert.DeserializeObject<Cliente>(response.Content.ReadAsStringAsync().Result);
        }
    }
}
