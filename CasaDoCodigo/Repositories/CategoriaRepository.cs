using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ApplicationContext contexto) : base(contexto)
        {
        }
        public async Task<IList<Categoria>> GetCategoria()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<Categoria> GetCategoria(string nomeCategoria)
        {
            return await dbSet.Where(x => x.Nome == nomeCategoria).FirstOrDefaultAsync();
        }

        public async Task SaveCategoria(string nomeCategoria)
        {
            var categoria = new Categoria(nomeCategoria);

            var categoriaExiste = dbSet.Where(x => x.Nome == nomeCategoria);

            if(categoriaExiste.Any())
            {
                throw new AggregateException($"A categoria \"{nomeCategoria}\" já existe");
            }

            dbSet.Add(categoria);

            await contexto.SaveChangesAsync();
        }
    }
}
