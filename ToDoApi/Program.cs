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
app.MapPost("api/todo", async([FromBody] ToDo newToDo, AppDbContext context) =>
{
    try
    {
        context.ToDos.Add(newToDo);
        await context.SaveChangesAsync();
        return Results.Ok("ToDo created");
    }
    catch
    {
        return Results.Problem();
    }
});

//Edit todo
app.MapPut("api/todo", async ([FromBody] ToDo changeToDo, AppDbContext context) =>
{
    var toDo = await context.ToDos.FirstOrDefaultAsync(x => x.Id == changeToDo.Id);

    if (toDo == null)
        return Results.NotFound();

    try
    {
        context.ToDos.Update(changeToDo);
        await context.SaveChangesAsync();
        return Results.Ok("ToDo changed");
    }
    catch
    {
        return Results.Problem();
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
        return Results.Problem();
    }
});

app.Run();
