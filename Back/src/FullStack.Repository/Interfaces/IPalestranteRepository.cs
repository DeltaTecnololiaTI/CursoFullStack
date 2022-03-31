using System.Threading.Tasks;
using FullStack.Domain.Entities;

namespace FullStack.Repository.Interfaces
{
    public interface IPalestranteRepository
    {
        Task<Palestrante[]> GetAllPalestrantesByTemaAsync(string tema, bool includePalestrantes  = false);
         Task<Palestrante[]> GetAllPalestrantesAsync(bool includePalestrantes  = false);
         Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includePalestrantes  = false);
    }
}