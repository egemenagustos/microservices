var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCarter();

builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(typeof(Program).Assembly);
    configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
    configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

var app = builder.Build();

//Configure the HTTP request pipeline.

app.MapCarter();

app.Run();
