using System.Linq;
using System.Threading.Tasks;
using FullStack.Domain.Entities;
using FullStack.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FullStack.Repository.Repositories
{
    public class PalestranteRepository : IPalestranteRepository
    {
        private readonly FullStackContext _context;
        public PalestranteRepository(FullStackContext context)
        {
            _context = context;

        }
        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes;
            query = query.Include(p => p.RedesSociais);
            if (includeEventos)
            {
                query = query.Include(p => p.PalestrantesEventos)
                        .ThenInclude(ep => ep.Evento);
            }
            query = query.AsNoTracking().OrderBy(p => p.Id);
            return (await query.ToArrayAsync());
        }
        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes;
            query = query.Where(p => p.Id == palestranteId)
                    .Include(p => p.RedesSociais);
            if (includeEventos)
            {
                query = query.Include(p => p.PalestrantesEventos)
                        .ThenInclude(ep => ep.Evento);
            }
            query = query.AsNoTracking().OrderBy(p => p.Id);
            return (await query.FirstOrDefaultAsync());
        }

        public async Task<Palestrante[]> GetAllPalestrantesByTemaAsync(string nome, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes;
            query = query.Where(p => p.Nome.ToLower().Contains(nome.ToLower()))
                    .Include(p => p.RedesSociais);
            if (includeEventos)
            {
                query = query.Include(p => p.PalestrantesEventos)
                        .ThenInclude(ep => ep.Evento);
            }
            query = query.AsNoTracking().OrderBy(p => p.Id);
            return (await query.ToArrayAsync());
        }

    }
}