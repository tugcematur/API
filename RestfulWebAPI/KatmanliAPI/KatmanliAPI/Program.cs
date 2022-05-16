using KatmanliAPI.Core;
using KatmanliAPI.Dal;
using KatmanliAPI.Repos;
using KatmanliAPI.Repos.Classes;
using KatmanliAPI.Repos.Interfaces;
using KatmanliAPI.Uow;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IUOFW, UOFW>();
builder.Services.AddScoped<IDersRepos, DersRepos>();
builder.Services.AddScoped<IOgrenciRepos, OgrenciRepos>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
