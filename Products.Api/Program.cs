global using FluentValidation;
global using FastEndpoints;

using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using Products.Api.Repositories;
using Products.Api.Services;
using System.Reflection;
using Products.Api.Contracts.Responses;
using Products.Api.Database.Contexts;
using Products.Api.Logger;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddDbContext<ProductsDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

app.UseDefaultExceptionHandler();

app.UseFastEndpoints(config =>
{
    config.Errors.ResponseBuilder = (failures, _) =>
    {
        return new ValidationFailureResponse
        {
            Errors = failures.Select(f => f.ErrorMessage).ToList()
        };
    };

    config.Endpoints.Configurator = ep =>
    {
        ep.PostProcessors(new ErrorLogger());
    };
});

app.UseOpenApi();
app.UseSwaggerUi3(x => x.ConfigureDefaults());

app.Run();