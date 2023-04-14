using Microsoft.EntityFrameworkCore;
using ToDoApiV3.Data;
using ToDoApiV3.Repository.IRepository;

namespace ToDoApiV3.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<TEntity> _entitiy;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _entitiy = _context.Set<TEntity>();
        }

        public async Task CreateAsync(TEntity item)
        {
            await _entitiy.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity item)
        {
            _entitiy.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            var result = await _entitiy.AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<TEntity> GetByIdAsync(string id)
        {
            var result = await _entitiy.FindAsync(id);

            if (result == null)
                throw new ArgumentNullException();

            return result;
        }

        /// <summary>
        /// Update ToDo
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task UpdateAsync(TEntity item)
        {
            if (item == null)
                throw new ArgumentNullException();

            //Ожидается, что перед обновление вызывается метод GetByIdAsync и в полученной из этого метода сущности вносятся изменения

            await _context.SaveChangesAsync();
        }
    }
}
