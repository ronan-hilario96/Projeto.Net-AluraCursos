using System.Collections.Generic;


namespace CasaDoCodigo.Models.ViewModels
{
    public class BuscaProdutosViewModel
    {
        public string Pesquisa { get; set; }
        public List<List<Produto>> Produtos { get; set; } = new List<List<Produto>>();
        public BuscaProdutosViewModel() { }
        public BuscaProdutosViewModel(string pesquisa) {
            this.Pesquisa = pesquisa;
        }
        public BuscaProdutosViewModel(List<List<Produto>> produtos)
        {
            this.Produtos = produtos;
        }

        public BuscaProdutosViewModel(string pesquisa, List<List<Produto>> produtos)
        {
            this.Pesquisa = pesquisa;
            this.Produtos = produtos;
        }
    }
}
