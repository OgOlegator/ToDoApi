using Microsoft.EntityFrameworkCore;
using ToDos.Persistence.Data;
using ToDoApiV2.Modules;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options
    => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//����������� �������� �� ModuleExtensions
builder.Services.RegisterModules();

var app = builder.Build();

//����������� Endpoints �� ModuleExtensions
app.MapEndpoints();

app.Run();
