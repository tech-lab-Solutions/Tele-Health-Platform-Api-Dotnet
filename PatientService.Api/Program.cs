using FreeMediator;
using PatientService.Api;
using PatientService.Api.Services;
using PatientService.Application.Patients.Commands.CreatePatient;
using PatientService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.AddSerilog();
builder.Services.AddOpenApi();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddCorsPolicy(builder.Configuration);

builder.Services.AddMediator(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining<CreatePatientCommand>();
    cfg.AddOpenBehavior(typeof(PatientService.Application.Common.Behaviors.ValidationBehavior<,>));
});

builder.Services.AddGrpc();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseRouting();

app.UseGrpcWeb();

app.UseCors("AllowFrontend");

app.MapGrpcService<PatientGrpcService>()
   .EnableGrpcWeb()
   .RequireCors("AllowFrontend");

app.MapGet("/", () => "Patient Service is running...");

app.Run();
