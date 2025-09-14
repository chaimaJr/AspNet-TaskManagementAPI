using Microsoft.EntityFrameworkCore;
using SwaggerThemes;
using TaskManagement.Data;
using TaskManagement.Repositories;
using TaskManagement.Services;

var builder = WebApplication.CreateBuilder(args);

//====================================
//             SERVICES
//====================================

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

// DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositories + Services
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IProjectService, ProjectService>();

//====================================


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(Theme.Dracula);
}

app.UseHttpsRedirection();

app.MapControllers();
app.Run();