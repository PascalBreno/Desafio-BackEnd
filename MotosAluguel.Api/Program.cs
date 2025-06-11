using MotosAluguel.Application.Interfaces.Orchestrators.Motorcycles;
using MotosAluguel.Application.Interfaces.Orchestrators.Rentals;
using MotosAluguel.Application.Interfaces.Orchestrators.Riders;
using MotosAluguel.Application.Orchestrators.Motorcycles;
using MotosAluguel.Application.Orchestrators.Rentals;
using MotosAluguel.Application.Orchestrators.Riders;
using MotosAluguel.Domain.Interfaces.Repositories.Motorcyles;
using MotosAluguel.Domain.Interfaces.Repositories.Rentals;
using MotosAluguel.Domain.Interfaces.Repositories.Riders;
using MotosAluguel.Domain.Interfaces.Validators.Motorcycles;
using MotosAluguel.Domain.Interfaces.Validators.Rentals;
using MotosAluguel.Domain.Interfaces.Validators.Riders;
using MotosAluguel.Domain.Validators.Motorcycles;
using MotosAluguel.Domain.Validators.Rentals;
using MotosAluguel.Domain.Validators.Riders;
using MotosAluguel.Infra.DbContext;
using MotosAluguel.Infra.Repositories.Motorcyles;
using MotosAluguel.Infra.Repositories.Rentals;
using MotosAluguel.Infra.Repositories.Riders;
using Npgsql;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IMotorcyclesInsertValidator, MotorcyclesValidator>();
builder.Services.Decorate<IMotorcyclesInsertValidator, MotorcyclesUniquePlateValidator>();

builder.Services.AddSingleton<IRiderInsertValidator, RiderValidator>();
builder.Services.Decorate<IRiderInsertValidator, RiderUniqueCnhValidator>();
builder.Services.Decorate<IRiderInsertValidator, RiderUniqueCnhValidator>();
builder.Services.Decorate<IRiderInsertValidator, RiderCnhTypeValidator>();

builder.Services.AddSingleton<IRentalValidator, RentalValidator>();
builder.Services.Decorate<IRentalValidator, RentalRiderExistValidator>();
builder.Services.Decorate<IRentalValidator, RentalRiderCnhTypeValidator>();
builder.Services.Decorate<IRentalValidator, RentalMotorcycleExistValidator>();


builder.Services.AddSingleton<IMotorcyclesReadRepository, MotorcyclesReaderRepository>();
builder.Services.AddSingleton<IMotorcycleWriterRepository, MotorcycleWriterRepository>();
builder.Services.Decorate<IMotorcycleWriterRepository, MotorcycleWriterRepositoryWithErrorHandler>();

builder.Services.AddSingleton<IRiderReaderRepository, RiderReaderRepository>();
builder.Services.AddSingleton<IRiderWriterRepository, RiderWriterRepository>();
builder.Services.Decorate<IRiderWriterRepository, RiderWriterRepositoryWithErrorHandler>();

builder.Services.AddSingleton<IRentalWriterRepository, RentalWriterRepository>();
builder.Services.Decorate<IRentalWriterRepository, RentalWriterRepositoryWithErrorHandler>();
builder.Services.AddSingleton<IRentalReaderRepository, RentalReaderRepository>();


builder.Services.AddSingleton<IMotorcycleQueryOrchestrator, MotorcycleQueryOrchestrator>();
builder.Services.AddSingleton<IMotorcycleInsertOrchestrator, MotorcycleInsertOrchestrator>();
builder.Services.AddSingleton<IMotorcycleUpdateOrchestrator, MotorcycleUpdateOrchestrator>();
builder.Services.AddSingleton<IMotorcycleDeleteOrchestrator, MotorcycleDeleteOrchestrator>();

builder.Services.AddSingleton<IRiderInsertOrchestrator, RiderInsertOrchestrator>();
builder.Services.AddSingleton<IRiderInsertCnhOrchestrator, RiderInsertCnhOrchestrator>();

builder.Services.AddSingleton<IRentalMotorcycleProcessOrchestrator, RentalMotorcycleProcessOrchestrator>();
builder.Services.AddSingleton<IRentalSettlementOrchestrator, RentalSettlementOrchestrator>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IDbConnection>(sp =>
    new NpgsqlConnection(sp.GetRequiredService<IConfiguration>().GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton<DatabaseWriterConnection>();
builder.Services.AddSingleton<DatabaseReaderConnection>();

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