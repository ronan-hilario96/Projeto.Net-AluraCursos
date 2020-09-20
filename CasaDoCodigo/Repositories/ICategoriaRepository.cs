using CasaDoCodigo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface ICategoriaRepository
    {
        Task SaveCategoria(string nomeCategoria);
        IList<Categoria> GetCategoria();
        Categoria GetCategoria(string nomeCategoria);
    }
}