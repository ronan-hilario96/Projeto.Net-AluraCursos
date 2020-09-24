using CasaDoCodigo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface ICategoriaRepository
    {
        Task SaveCategoria(string nomeCategoria);
        Task<IList<Categoria>> GetCategoria();
        Task<Categoria> GetCategoria(string nomeCategoria);
        Task<bool> Validar(string nomeCategoria);
    }
}