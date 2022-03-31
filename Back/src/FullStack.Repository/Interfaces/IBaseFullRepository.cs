using System.Threading.Tasks;

namespace FullStack.Repository.Interfaces
{
    public interface IBaseFullRepository
    {
        //GERAL
         void Add<T>(T entity) where T : class;
         void Update<T>(T entity) where T : class;
         void Delete<T>(T entity) where T : class;
         void DeleteRange<T>(T[] entity) where T : class;
         Task<bool>SaveChangesAsync();


    }
}