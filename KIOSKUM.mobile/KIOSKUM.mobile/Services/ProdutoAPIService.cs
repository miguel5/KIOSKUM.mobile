using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using KIOSKUM.mobile.Models;
using System.Linq;
using System.Net.Http.Headers;
using System.Collections.ObjectModel;

namespace KIOSKUM.mobile.Services
{
    public class ProdutoAPIService
    {
        private const string URL_GetProdutosByCategoria = "https://kioskum.azurewebsites.net/api/categoria/produtos/ativados?idCategoria=";
        private const string URL_GetCategorias = "https://kioskum.azurewebsites.net/api/categoria/ativadas";
        HttpClient Client = new HttpClient();
        private Dictionary<int, Categoria> Categorias;

        public ProdutoAPIService() {
            Categorias = new Dictionary<int, Categoria>();
        }

        public async Task<IEnumerable<Produto>> GetItemsAsync()
        {
            try
            {
                Client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", App.AuthToken.Token);

                var categorias = await GetCategorias();
                List<Produto> produtos = new List<Produto>();
                
                // Popular o dicionario de categorias
                foreach(Categoria c in categorias)
                {
                    Categorias.Add(c.IdCategoria, c);
                    var prodsCat = await GetProdutosByCategoria(c.IdCategoria);
                    foreach(SProduto p in prodsCat)
                    {
                        produtos.Add(p.ToProduto(c.Nome));
                    }
                }                

                return produtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*
         * Devolve todas as categorias ativas
         */
        public async Task<IEnumerable<Categoria>> GetCategorias()
        {
            try
            {
                Client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", App.AuthToken.Token);

                var response = await Client.GetStringAsync(URL_GetCategorias);
                var categorias = JsonConvert.DeserializeObject<List<Categoria>>(response);


                return categorias;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*
         * Devolve a lista de todos os produtos pertencentes a uma dada categoria
         */
        private async Task<IEnumerable<SProduto>> GetProdutosByCategoria(int categoria)
        {
            try
            {
                Client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", App.AuthToken.Token);

                var response = await Client.GetStringAsync(URL_GetProdutosByCategoria + categoria);
                var produtos = JsonConvert.DeserializeObject<List<SProduto>>(response);


                return produtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    /*
     * Classe de um produto vindo do servidor (igual à classe Models.Produto mas com IdCatagoria como int)
     */
    class SProduto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdCategoria { get; set; }
        public double Preco { get; set; }
        public IList<string> Ingredientes { get; set; }
        public IList<string> Alergenios { get; set; }
        public string URL { get; set; }

        public SProduto() { }

        public Produto ToProduto(string nomeCategoria)
        {
            return new Produto(Id, Nome, nomeCategoria, Preco, Ingredientes, Alergenios, URL);
        }
    }
}
