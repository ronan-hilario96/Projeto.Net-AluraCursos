using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models.ViewModels
{
    public class ListaProdutosViewModel
    {
        public IList<Produto> Produtos { get; set; }
        public string NomeCategoria { get; set; }
        public ListaProdutosViewModel() { }
        public ListaProdutosViewModel(string nomeCategoria, IList<Produto> produtos)
        {
            NomeCategoria = nomeCategoria;
            Produtos = produtos;
        }
    }
}
