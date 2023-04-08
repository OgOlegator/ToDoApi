using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ToDoApiV2.Data;
using ToDoApiV2.Models;
using ToDoApiV2.Modules.ToDos.Ports;

namespace ToDoApiV2.Modules.ToDos.Adapters
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly AppDbContext _db;

        public ToDoRepository(AppDbContext context)
        {
            _db = context;
        }

        /// <summary>
        /// Get all ToDo
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ToDo>> Get()
        {
            var result = await _db.ToDos.ToListAsync();

            return result;
        }

        /// <summary>
        /// Get ToDo by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<ToDo> GetById(string id)
        {
            var result = await _db.ToDos.FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
                throw new ArgumentNullException();

            return result;
        }

        /// <summary>
        /// Create ToDo
        /// </summary>
        /// <param name="toDo"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task Create(ToDo toDo)
        {
            try
            {
                await _db.ToDos.AddAsync(toDo);
                await _db.SaveChangesAsync();
            }
            catch
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Edit ToDo
        /// </summary>
        /// <param name="toDo"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task Update(ToDo toDo)
        {
            var toDoModel = await _db.ToDos.FindAsync(toDo.Id);

            if (toDoModel == null)
                throw new ArgumentNullException();

            try
            {
                toDoModel.Name = toDo.Name;
                await _db.SaveChangesAsync();
            }
            catch
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Delete ToDo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task DeleteById(string id)
        {
            var toDo = await _db.ToDos.FirstOrDefaultAsync(x => x.Id == id);

            if (toDo == null)
                throw new ArgumentNullException();

            try
            {
                _db.ToDos.Remove(toDo);
                await _db.SaveChangesAsync();
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
