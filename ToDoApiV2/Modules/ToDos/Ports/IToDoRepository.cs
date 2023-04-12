using ToDos.Core.Models;

namespace ToDoApiV2.Modules.ToDos.Ports
{
    public interface IToDoRepository
    {

        Task<IEnumerable<ToDo>> Get();

        Task<ToDo> GetById(string id);

        Task Create(ToDo toDo);

        Task Update(ToDo toDo);

        Task DeleteById(string id);

    }
}
