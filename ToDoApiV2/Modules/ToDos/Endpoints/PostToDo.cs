using ToDos.Core.Models;
using ToDoApiV2.Modules.ToDos.Ports;

namespace ToDoApiV2.Modules.ToDos.Endpoints
{
    public class PostToDo
    {

        public static async Task<IResult> CreateAsync(ToDo toDo, IToDoRepository repository)
        {
            try
            {
                await repository.Create(toDo);
                return Results.Created($"api/todo/{toDo.Id}", toDo);
            }
            catch
            {
                return Results.BadRequest();
            }
        }

    }
}
