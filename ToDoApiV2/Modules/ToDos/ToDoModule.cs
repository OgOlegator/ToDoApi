using ToDoApiV2.Models;
using ToDoApiV2.Modules.ToDos.Adapters;
using ToDoApiV2.Modules.ToDos.Endpoints;
using ToDoApiV2.Modules.ToDos.Ports;

namespace ToDoApiV2.Modules.ToDos
{
    public class ToDoModule : IModule
    {
        public IServiceCollection RegisterModule(IServiceCollection services)
        {
            services.AddScoped<IToDoRepository, ToDoRepository>();
            return services;
        }

        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            //Get all
            endpoints.MapGet("api/todo", async (IToDoRepository repository)
                => await GetToDo.GetAllAsync(repository));

            //Get by id
            endpoints.MapGet("api/todo/{id}", async (string id, IToDoRepository repository) 
                => await GetToDo.GetByIdAsync(id, repository));

            //Create todo
            endpoints.MapPost("api/todo", async (ToDo newToDo, IToDoRepository repository) 
                => await PostToDo.CreateAsync(newToDo, repository));

            //Edit todo
            endpoints.MapPut("api/todo", async (ToDo changeToDo, IToDoRepository repository) 
                => await PutToDo.UpdateAsync(changeToDo, repository));

            //Delete todo
            endpoints.MapDelete("api/todo/{id}", async (string id, IToDoRepository repository) 
                => await DeleteToDo.DeleteAsync(id, repository));

            return endpoints;
        }
    }
}
