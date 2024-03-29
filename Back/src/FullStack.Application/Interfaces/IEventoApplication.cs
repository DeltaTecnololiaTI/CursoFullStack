using System.Threading.Tasks;
using FullStack.Domain.Entities;

namespace FullStack.Application.Interfaces
{
    public interface IEventoApplication
    {
         Task<Evento> AddEventos (Evento model);
         Task<Evento> UpdateEvento (int eventoId, Evento model);
         Task<bool> DeleteEvento (int eventoId);
         Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false );
         Task<Evento[]> GetAllEventosAsync(bool includePalestrantes  = false);
         Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes  = false);
    }
}