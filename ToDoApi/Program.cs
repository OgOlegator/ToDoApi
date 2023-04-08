using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;
using ToDoApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options
    => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

//Get all
app.MapGet("api/todo", async (AppDbContext context) =>
{
    var items = await context.ToDos.ToListAsync();

    return Results.Ok(items);
});

//Get by id
app.MapGet("api/todo/{id}", async (string id, AppDbContext context) =>
{
    var item = await context.ToDos.FirstOrDefaultAsync(x => x.Id == id);

    return Results.Ok(item);
});

//Create todo
app.MapPost("api/todo", async(ToDo newToDo, AppDbContext context) =>
{
    try
    {
        await context.ToDos.AddAsync(newToDo);
        await context.SaveChangesAsync();
        return Results.Created($"api/todo/{newToDo.Id}", newToDo);
    }
    catch
    {
        return Results.BadRequest();
    }
});

//Edit todo
app.MapPut("api/todo", async (ToDo changeToDo, AppDbContext context) =>
{
    var toDoModel = await context.ToDos.FindAsync(changeToDo.Id);

    if (toDoModel == null)
        return Results.NotFound();

    try
    {
        toDoModel.Name = changeToDo.Name;
        await context.SaveChangesAsync();
        return Results.Ok("ToDo changed");
    }
    catch
    {
        return Results.BadRequest();
    }
});

//Delete todo
app.MapDelete("api/todo/{id}", async (string id, AppDbContext context) =>
{
    var toDo = await context.ToDos.FirstOrDefaultAsync(x => x.Id == id);

    if (toDo == null)
        return Results.NotFound();

    try
    {
        context.ToDos.Remove(toDo);
        await context.SaveChangesAsync();
        return Results.Ok("ToDo deleted");
    }
    catch
    {
        return Results.BadRequest();
    }
});

app.Run();
