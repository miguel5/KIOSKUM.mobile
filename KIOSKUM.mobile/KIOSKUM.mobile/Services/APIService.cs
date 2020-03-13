using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using KIOSKUM.mobile.Models;

namespace KIOSKUM.mobile.Services
{
    class APIService
    {
        HttpClient Client = new HttpClient();
        public async Task<List<Produto>> GetProdutosAsync()
        {
            try
            {
                string url = "https://kioskum.azurewebsites.net/api/Produto/Todos";
                var response = await Client.GetStringAsync(url);
                var produtos = JsonConvert.DeserializeObject<List<Produto>>(response);
                Console.WriteLine(produtos[0].ToString());                                     // Debug
                return produtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
