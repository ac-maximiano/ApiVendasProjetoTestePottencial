using Pottencial.Teste.Infra.IoC;
using Pottencial.Teste.Presentation.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerConfiguration()
    .AddInfrastructure(builder.Configuration)
    .AddAutoMapperConfiguration();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStatusCodePages();
app.MapControllers();
app.Run();
