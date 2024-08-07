using System;
using Microsoft.EntityFrameworkCore;
using Training.Api.Entities;

namespace Training.Api.Infrastructure;

public class ConnectionContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Employee> Employee { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=localhost;Database=Training;User Id=postgres;Password=password;");
    }
}
