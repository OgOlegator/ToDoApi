namespace ToDoApiV3.Repository.IRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {

        Task<IEnumerable<TEntity>> GetAsync();

        Task<TEntity> GetByIdAsync(string id);

        Task CreateAsync(TEntity item);

        Task UpdateAsync(TEntity item);

        Task DeleteAsync(TEntity item);
        
    }
}
