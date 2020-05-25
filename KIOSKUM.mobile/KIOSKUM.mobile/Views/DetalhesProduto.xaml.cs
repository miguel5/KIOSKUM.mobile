using KIOSKUM.mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KIOSKUM.mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalhesProduto : ContentPage
    {
        public Produto Produto { get; set; }

        public DetalhesProduto(Produto produto)
        {
            Produto = produto;

            BindingContext = this;

            InitializeComponent();

            Title = Produto.Nome;
        }
    }
}