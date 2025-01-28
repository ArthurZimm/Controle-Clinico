using ControleClinico.Application.Contracts.Persistence;
using ControleClinico.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ControleClinico.Infraestructure.Implementations
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        private readonly ClinicalDbContext _context;

        public BaseRepository(ClinicalDbContext context)
        {
            _context = context;
        }

        public async Task<T?> GetByIdAsync(int id)
        {
           return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>?> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<T?> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }


        public async Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>().Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T?> GetByNameAsync(string name)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => EF.Property<string>(x, "Name") == name);
        }
    }
}