using System.Threading.Tasks;
using FullStack.Domain.Entities;

namespace FullStack.Application.Interfaces
{
    public interface IPalestranteApplication
    {
        Task<Palestrante> AddPalestrantes (Palestrante model);
         Task<Palestrante> UpdatePalestrante (Palestrante model);
         Task<Palestrante> DeletePalestrante (Palestrante model);
         Task<Palestrante[]> GetAllPalestrantesByTemaAsync(string tema, bool includePalestrantes  = false);
         Task<Palestrante[]> GetAllPalestrantesAsync(bool includePalestrantes  = false);
         Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includePalestrantes  = false);
    }
}