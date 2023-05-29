using System.Data;
using System.Reflection;
using AutoMapper;
using Dapper_Data_Access_Layer.EntitiesRepositories;
using Dapper_Data_Access_Layer.EntitiesRepositories.Interfaces;
using Dapper_Data_Access_Layer.GenericRepository_UnitOfWork;
using Dapper_Data_Access_Layer.GenericRepository_UnitOfWork.Interfaces;
using Dapper_Data_Access_Layer.Repository.RepositoryPattern;
using Dapper_Data_Access_Layer.Repository.RepositoryPattern.Interfaces;
using Dapper_Example_Bussines_Logic.DataTrasferObjects.Services;
using Dapper_Example_Bussines_Logic.DataTrasferObjects.Services.Interfaces;
using Movies_Management_System_API.Mapping;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Logging.ClearProviders();

builder.Logging.AddConsole();

// Seth the configurations for the Swagger and uncluding xml comments to the actions
builder.Services.AddSwaggerGen(options =>
{
    // Swagger options and naming: 
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Movie Theater Reservation System",
        Description = "Do you like going to the movies? Have you ever considered what the database design behind their reservation system looks like? In this article we’ll prepare an example database model for a movie theater."
    });

    // Including xml comments for inserting commment in Swagger: 
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

// Set the connections to the database: 
builder.Services.AddScoped<SqlConnection>(configurations => new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IDbTransaction>(configurations =>
{
    // Opening the connection:
    SqlConnection connection = configurations.GetRequiredService<SqlConnection>();
    connection.Open();
    return connection.BeginTransaction();
});

// Including all Dependenciens for the Container 
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieServices, MovieServices>();

var app = builder.Build();

// Set the configurations for the Swagger endpoints (routes) 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(s =>
    {
        s.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger API Version");
        s.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
