using MotosAluguel.Application.Interfaces.Orchestrators.Motorcycles;
using MotosAluguel.Application.Orchestrators.Motorcycles;
using MotosAluguel.Domain.Interfaces.Repositories.Motorcyles;
using MotosAluguel.Domain.Interfaces.Validators.Motorcycles;
using MotosAluguel.Domain.Validators.Motorcycles;
using MotosAluguel.Infra.DbContext;
using MotosAluguel.Infra.Repositories.Motorcyles;
using Npgsql;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IDbConnection>(sp =>
    new NpgsqlConnection(sp.GetRequiredService<IConfiguration>().GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton<DatabaseWriterConnection>();
builder.Services.AddSingleton<DatabaseReaderConnection>();

builder.Services.AddSingleton<IMotorcycleInsertOrchestrator, MotorcycleInsertOrchestrator>();

builder.Services.AddSingleton<IMotorcyclesInsertValidator, MotorcyclesValidator>();
builder.Services.Decorate<IMotorcyclesInsertValidator, MotorcyclesUniquePlateValidator>();

builder.Services.AddSingleton<IMotorcyclesReadRepository, MotorcyclesReaderRepository>();

builder.Services.AddSingleton<IMotorcycleWriterRepository, MotorcycleWriterRepository>();
builder.Services.Decorate<IMotorcycleWriterRepository, MotorcycleWriterRepositoryWithErrorHandler>();

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
