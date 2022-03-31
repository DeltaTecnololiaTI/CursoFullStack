using System.Threading.Tasks;
using FullStack.Domain.Entities;

namespace FullStack.Repository.Interfaces
{
    public interface IEventoRepository
    {        
         Task<Evento[]> GetEventosByTemaAsync(string tema, bool includePalestrantes = false );
         Task<Evento[]> GetAllEventosAsync(bool includePalestrantes  = false);
         Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes  = false);
    }
}