using Microsoft.EntityFrameworkCore;
using PoupaDev.API.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Injeção de Dependencia 
// Add services to the container.
//builder.Services.AddSingleton<PoupaDevDbContext>();

var connectionString = builder.Configuration.GetConnectionString("PoupaDevCs");
//var connectionString = builder.Configuration.GetConnectionString("PoupaDevCs");

// Db em produção
builder.Services.AddDbContext<PoupaDevDbContext>(o => o.UseSqlServer(connectionString));

//Para Teste em memoria
//builder.Services.AddDbContext<PoupaDevDbContext>(o => o.UseInMemoryDatabase("PoupaDevDb"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
