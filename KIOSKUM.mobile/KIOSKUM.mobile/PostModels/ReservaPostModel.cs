using System;
using System.Collections.Generic;
using System.Text;

namespace KIOSKUM.mobile.PostModels
{
    public class ReservaPostModel
    {
        public List<ReservaItem> Itens { get; set; }
        public string HoraEntrega { get; set; }
    }

    public class ReservaItem
    {
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
        public string Observacoes { get; set; }
    }
}
