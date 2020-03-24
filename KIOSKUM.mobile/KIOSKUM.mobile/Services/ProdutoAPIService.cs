using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using KIOSKUM.mobile.Models;
using System.Linq;

namespace KIOSKUM.mobile.Services
{
    class ProdutoAPIService : IDataStore<Produto>
    {
        readonly List<Produto> Produtos;
        HttpClient Client = new HttpClient();

        public ProdutoAPIService() {
            Produtos = this.GetItemsAsync().Result.ToList();
        }

        public async Task<IEnumerable<Produto>> GetItemsAsync(bool forceRefresh = false)
        {
            try
            {
                string url = "https://kioskum.azurewebsites.net/api/Produto/Todos";
                var response = await Client.GetStringAsync(url);
                var produtos = JsonConvert.DeserializeObject<List<Produto>>(response);
                return produtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> AddItemAsync(Produto produto)
        {
            Produtos.Add(produto);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Produto produto)
        {

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {

            return await Task.FromResult(true);
        }

        public async Task<Produto> GetItemAsync(string id)
        {
            int x = Int32.Parse(id);

            return await Task.FromResult(Produtos.FirstOrDefault(s => s.Id == x));
        }
    }
}
