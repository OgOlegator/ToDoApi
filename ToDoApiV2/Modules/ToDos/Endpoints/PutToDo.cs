using ToDoApiV2.Models;
using ToDoApiV2.Modules.ToDos.Ports;

namespace ToDoApiV2.Modules.ToDos.Endpoints
{
    public class PutToDo
    {

        public static async Task<IResult> UpdateAsync(ToDo toDo, IToDoRepository repository)
        {
            try
            {
                await repository.Update(toDo);
                return Results.Ok("ToDo changed");
            }
            catch (ArgumentNullException)
            {
                return Results.NotFound(toDo.Id);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex);
            }
        }

    }
}
