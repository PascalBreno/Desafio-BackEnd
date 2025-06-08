using MotosAluguel.Domain.Interfaces.Repositories;
using MotosAluguel.Infra.DbContext;
using MotosAluguel.Infra.Repositories;
using Npgsql;
using System.Data;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IDbConnection>(sp =>
    new NpgsqlConnection(sp.GetRequiredService<IConfiguration>().GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton<DatabaseConnection>();

builder.Services.AddSingleton<IMotorCycleWriterRepository, MotorCycleWriterRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
