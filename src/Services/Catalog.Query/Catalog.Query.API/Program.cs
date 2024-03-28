using BuildingBlocks.Exceptions.Handlers;
using Marten;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

builder.Services.AddCarter();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});

builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

builder.Services.AddExceptionHandler<ApplicationExceptionHandler>();

// TODO: Question => What is light weight session

var app = builder.Build();

// Configure the HTTP request pipeline

app.MapCarter();

app.UseExceptionHandler(option => {});

app.Run();
