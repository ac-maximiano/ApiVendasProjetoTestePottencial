using Pottencial.Teste.Infra.IoC;
using Pottencial.Teste.Presentation.Api.Configurations;
using Pottencial.Teste.Presentation.Api.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(builder =>
{
    builder.AddConsole();
});

builder.Services.AddControllers(options =>
{
    options.Filters.Add<CustomExceptionFilter>();
});

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerConfiguration()
    .AddInfrastructure(builder.Configuration)
    .AddAutoMapperConfiguration()
    .AddFilters();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        options.RouteTemplate = "api-docs/{documentName}/open-api.json";
    });
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/api-docs/v1/open-api.json", "Payment V1");
        options.RoutePrefix = "api-docs";
    });
}

app.UseHttpsRedirection();
app.UseStatusCodePages();
app.MapControllers();
app.Run();
