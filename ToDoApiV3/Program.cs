using Microsoft.EntityFrameworkCore;
using ToDoApiV3.Data;
using ToDoApiV3.Models;
using ToDoApiV3.Repository;
using ToDoApiV3.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options
    => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IGenericRepository<ToDo>, GenericRepository<ToDo>>();

var app = builder.Build();

//Get all
app.MapGet("api/todo", async (IGenericRepository<ToDo> repository) =>
{
    try
    {
        var items = await repository.GetAsync();
        return Results.Ok(items);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex);
    }
});

//Get by id
app.MapGet("api/todo/{id}", async (string id, IGenericRepository<ToDo> repository) =>
{
    try
    {
        var item = await repository.GetByIdAsync(id);
        return Results.Ok(item);
    }
    catch (ArgumentNullException)
    {
        return Results.NotFound();
    }
});

//Create todo
app.MapPost("api/todo", async (ToDo newToDo, IGenericRepository<ToDo> repository) =>
{
    try
    {
        await repository.CreateAsync(newToDo);
        return Results.Created($"api/todo/{newToDo.Id}", newToDo);
    }
    catch
    {
        return Results.BadRequest();
    }
});

//Edit todo
app.MapPut("api/todo", async (ToDo changeToDo, IGenericRepository<ToDo> repository) =>
{
    var toDoModel = await repository.GetByIdAsync(changeToDo.Id);

    if (toDoModel == null)
        return Results.NotFound();

    try
    {
        toDoModel.Name = changeToDo.Name;
        await repository.UpdateAsync(toDoModel);
        return Results.Ok("ToDo changed");
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex);
    }
});

//Delete todo
app.MapDelete("api/todo/{id}", async (string id, IGenericRepository<ToDo> repository) =>
{
    var toDo = await repository.GetByIdAsync(id);

    if (toDo == null)
        return Results.NotFound();

    try
    {
        await repository.DeleteAsync(toDo);
        return Results.Ok("ToDo deleted");
    }
    catch
    {
        return Results.BadRequest();
    }
});

app.Run();
