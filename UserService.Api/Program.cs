using FluentValidation;
using FreeMediator;
using UserService.Api;
using UserService.Api.Services;
using UserService.Application.Users.Commands.CreateUser;
using UserService.Application.Users.Commands.UpdateUser;
using UserService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

//added Serilog for logging
builder.AddSerilog();

builder.Services.AddOpenApi();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddMediator(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining<CreateUserCommand>();
    cfg.AddOpenBehavior(typeof(UserService.Application.Common.Behaviors.ValidationBehavior<,>));
});


builder.Services.AddGrpc();

builder.Services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateUserCommandValidator>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseHttpsRedirection();
app.MapGrpcService<UserGrpcService>();
app.MapGet("/", () => "This service supports REST and gRPC.");

app.Run();
