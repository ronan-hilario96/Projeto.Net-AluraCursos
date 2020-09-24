using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        private ICategoriaRepository _categoriaRepository;
        public ProdutoRepository(ApplicationContext contexto, ICategoriaRepository categoriaRepository) : base(contexto)
        {
            _categoriaRepository = categoriaRepository;
        }

        public IList<Produto> GetProdutos()
        {
            return dbSet.Include(i => i.Categoria).ToList();
        }
        public async Task<IList<Produto>> GetProdutos(string pesquisa)
        {
            IList<Produto> retorno;

            if(!string.IsNullOrEmpty(pesquisa))
            {
                retorno = await dbSet.Include(i => i.Categoria)
                        .Where(x => x.Nome.Contains(pesquisa) || x.Categoria.Nome.Contains(pesquisa))
                        .ToListAsync();
            } else
            {
                retorno = await dbSet.Include(i => i.Categoria).ToListAsync();
            }

            return retorno;
        }

        public async Task SaveProdutos(List<Livro> livros)
        {
            foreach (var livro in livros)
            {
                if (!dbSet.Where(p => p.Codigo == livro.Codigo).Any())
                {
                    var categoriaValida = await _categoriaRepository.Validar(livro.Categoria);

                    if (categoriaValida)
                    {
                        var obtemCategoria = await _categoriaRepository.GetCategoria(livro.Categoria);

                        dbSet.Add(new Produto(livro.Codigo, livro.Nome, livro.Preco, obtemCategoria));
                    }
                }
            }
            await contexto.SaveChangesAsync();
        }
    }

    public class Livro
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string Subcategoria { get; set; }
        public decimal Preco { get; set; }
    }
}
