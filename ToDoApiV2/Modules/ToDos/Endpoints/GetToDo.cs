using ToDoApiV2.Modules.ToDos.Ports;

namespace ToDoApiV2.Modules.ToDos.Endpoints
{
    public class GetToDo
    {
        public static async Task<IResult> GetAllAsync(IToDoRepository repository)
        {
            var items = await repository.Get();

            return Results.Ok(items);
        }

        public static async Task<IResult> GetByIdAsync(string id, IToDoRepository repository)
        {
            try
            {
                var items = await repository.GetById(id);

                return Results.Ok(items);
            }
            catch (ArgumentNullException)
            {
                return Results.NotFound(id);
            }
        }

    }
}
