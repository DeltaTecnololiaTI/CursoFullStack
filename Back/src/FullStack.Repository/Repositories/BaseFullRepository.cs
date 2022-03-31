using System.Linq;
using System.Threading.Tasks;
using FullStack.Domain.Entities;
using FullStack.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FullStack.Repository.Repositories
{
    public class BaseFullRepository : IBaseFullRepository
    {
        private readonly FullStackContext _context;
        public BaseFullRepository(FullStackContext context)
        {
            _context = context;
            
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
        



    }
}