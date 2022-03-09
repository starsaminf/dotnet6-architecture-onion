using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjectName.WebApi.DependencyInjection;
using ProjectName.Services.DependencyInjection;
using ProjectName.Infrastructure.Database.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices();
builder.Services.AddMongoClient();
builder.Services.AddRepositories();
builder.Services.AddWebApiControllers();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Example", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Example v1"));
}

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
