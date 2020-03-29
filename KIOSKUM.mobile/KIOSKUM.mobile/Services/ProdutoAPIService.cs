using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using KIOSKUM.mobile.Models;
using System.Linq;

namespace KIOSKUM.mobile.Services
{
    class ProdutoAPIService
    {
        private const string URL_GetProdutos = "https://kioskum.azurewebsites.net/api/Produto/Todos";
        HttpClient Client = new HttpClient();

        public ProdutoAPIService() {

        }

        public async Task<IEnumerable<Produto>> GetItemsAsync(bool forceRefresh = false)
        {
            try
            {
                var response = await Client.GetStringAsync(URL_GetProdutos);
                var produtos = JsonConvert.DeserializeObject<List<Produto>>(response);
                return produtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
