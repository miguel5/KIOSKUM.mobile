using System;
using System.Collections.Generic;
using System.Text;

namespace KIOSKUM.mobile.Models
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public string NomeCategoria { get; set; }
        public double Preco { get; set; }
        public IList<string> Ingredientes { get; set; }
        public IList<string> Alergenios { get; set; }
        public string URL { get; set; }


        public Produto(int IdProduto, string Nome, string NomeCategoria, double Preco, IList<string> Ingredientes, IList<string> Alergenios, string URL)
        {
            this.IdProduto = IdProduto;
            this.Nome = Nome;
            this.NomeCategoria = NomeCategoria;
            this.Preco = Preco;
            this.Ingredientes = Ingredientes;
            this.Alergenios = Alergenios;
            this.URL = URL;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 3;
                hash = 37 * hash + IdProduto;
                hash = 37 * hash + (Nome == null ? 0 : Nome.GetHashCode());
                hash = 37 * hash + (NomeCategoria == null ? 0 : NomeCategoria.GetHashCode());
                hash = 37 * hash + Preco.GetHashCode();
                hash = 37 * hash + (Ingredientes == null ? 0 : Ingredientes.GetHashCode());
                hash = 37 * hash + (Alergenios == null ? 0 : Alergenios.GetHashCode());
                return hash;
            }
        }

        public override bool Equals(Object obj)
        {
            if (obj == this)
            {
                return true;
            }
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            Produto produto = (Produto)obj;
            return IdProduto == produto.IdProduto;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Produto\n");
            sb.Append("- ID : " + IdProduto + "\n");
            sb.Append("- Nome : " + Nome + "\n");
            sb.Append("- Categoria : " + NomeCategoria + "\n");
            sb.Append("- Preco : " + Preco + "\n");
            sb.Append("- Ingredientes: ");
            foreach (var ingrediente in Ingredientes)
            {
                sb.Append(ingrediente + "; ");
            }
            sb.Append("\n- Alergénios: ");
            foreach (var alergenio in Alergenios)
            {
                sb.Append(alergenio + "; ");
            }
            return sb.ToString();
        }

    }
}
