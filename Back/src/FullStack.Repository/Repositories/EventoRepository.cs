using System.Linq;
using System.Threading.Tasks;
using FullStack.Domain.Entities;
using FullStack.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FullStack.Repository.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly FullStackContext _context;
        public EventoRepository(FullStackContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        }
        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Domain.Entities.Evento> query = _context.Eventos;
            query = query.Include(e => e.Lotes)
                    .Include(e => e.RedesSociais);
            if (includePalestrantes)
            {
                query = query.Include(e => e.PalestrantesEventos)
                        .ThenInclude(pe => pe.Palestrante);
            }
            query = query.OrderBy(e => e.Id);
            return (await query.ToArrayAsync());
        }
        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos;
            query = query.Where(e => e.Id == eventoId)
                    .Include(e => e.Lotes)
                    .Include(e => e.RedesSociais);
            if (includePalestrantes)
            {
                query = query.Include(e => e.PalestrantesEventos)
                        .ThenInclude(ep => ep.Palestrante);
            }
            query = query.OrderBy(e => e.Id);
            return (await query.FirstOrDefaultAsync());
        }

        public async Task<Evento[]> GetEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos;
            query = query.Where(e => e.Tema.ToLower().Contains(tema.ToLower()))
                    .Include(e => e.Lotes)
                    .Include(e => e.RedesSociais);
            if (includePalestrantes)
            {
                query = query.Include(e => e.PalestrantesEventos)
                        .ThenInclude(ep => ep.Palestrante);
            }
            query = query.OrderBy(e => e.Tema);
            return (await query.ToArrayAsync());
        }
    }
}