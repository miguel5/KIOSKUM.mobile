﻿using KIOSKUM.mobile.Models;
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

        public async Task<ErrorsList> CriarConta(CriarContaPostModel conta)
        {
            try
            {
                var content = JsonConvert.SerializeObject(conta);

                var response = await _client.PostAsync(URL_criar, new StringContent(content, Encoding.UTF8, "application/json"));
                Console.WriteLine("Resposta: " + response.Content.ReadAsStringAsync().Result);

                if (response.IsSuccessStatusCode)
                {
                    return new ErrorsList();
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
    }
}
