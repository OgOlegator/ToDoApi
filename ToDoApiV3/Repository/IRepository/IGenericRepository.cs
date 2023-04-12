namespace ToDoApiV3.Repository.IRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {

        IEnumerable<TEntity> Get();

        TEntity GetById(string id);

        void Create(TEntity item);

        void Update(TEntity item);

        void Delete(TEntity item);
        
    }
}
