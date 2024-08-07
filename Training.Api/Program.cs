
using Microsoft.EntityFrameworkCore;
using Training.Api.Infrastructure;
using Training.Api.Interfaces.Repository;
using Training.Api.Interfaces.Service;
using Training.Api.Repositories;
using Training.Api.Services;

namespace Training.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<ConnectionContext>(options =>
        {
            options.UseNpgsql("Server=localhost;Database=Training;Trusted_Connection=True;User Id=postgres;Password=password;");
        });

        // Registering the repository
        builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

        // Registering the service
        builder.Services.AddScoped<IEmployeeService, EmployeeService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
