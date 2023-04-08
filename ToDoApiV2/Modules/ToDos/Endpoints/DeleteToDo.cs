using ToDoApiV2.Modules.ToDos.Ports;

namespace ToDoApiV2.Modules.ToDos.Endpoints
{
    public class DeleteToDo
    {

        public static async Task<IResult> DeleteAsync(string id, IToDoRepository repository)
        {
            try
            {
                await repository.DeleteById(id);
                return Results.Ok("ToDo deleted");
            }
            catch (ArgumentNullException)
            {
                return Results.NotFound(id);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex);
            }
        }

    }
}
