
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace KIOSKUM.mobile.Models
{
    public class CarrinhoItem
    {
        public string Id { get; set; }   // Volta a mudar para int!!
        public int Qtd { get; set; }
        public string Obs { get; set; }

        public override bool Equals(object obj)
        {
            return obj is CarrinhoItem item &&
                   Id == item.Id &&
                   Qtd == item.Qtd &&
                   Obs == item.Obs;
        }

        public override int GetHashCode()
        {
            int hashCode = -1629259719;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + Qtd.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Obs);
            return hashCode;
        }
    }
}
