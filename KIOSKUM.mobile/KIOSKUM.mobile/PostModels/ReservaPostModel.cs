using KIOSKUM.mobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace KIOSKUM.mobile.PostModels
{
    public class ReservaPostModel
    {
        public List<ReservaItem> Itens { get; set; }
        public string HoraEntrega { get; set; }

        /*
         * Construtor que facilita a transformacao de uma lista de CarrinhoItem  
         * para uma lista de ReservaItem e formata a hora adequadamente
         */
        public ReservaPostModel(ObservableCollection<CarrinhoItem> items, TimeSpan hora)
        {
            Itens = new List<ReservaItem>();
            HoraEntrega = string.Format("{0:yyyy-MM-dd}T{1:hh\\:mm\\:ss\\.ffffff}", DateTime.Today, hora);

            foreach (CarrinhoItem c in items)
            {
                Itens.Add(new ReservaItem { IdProduto = c.Id, Observacoes = c.Obs, Quantidade = c.Qtd });
            }
        }
    }

    public class ReservaItem
    {
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
        public string Observacoes { get; set; }
    }
}
