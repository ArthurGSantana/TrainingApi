using System;
using Microsoft.EntityFrameworkCore;
using Training.Api.Entities;

namespace Training.Api.Infrastructure;

public class ConnectionContext(DbContextOptions<ConnectionContext> options) : DbContext(options)
{
    public DbSet<Employee> Employee { get; set; }
}
