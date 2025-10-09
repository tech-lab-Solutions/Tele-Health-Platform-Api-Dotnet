using DoctorService.Api;
using DoctorService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.AddSerilog();
builder.Services.AddOpenApi();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddCorsPolicy(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseRouting();

app.Run();
