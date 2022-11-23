using Microsoft.EntityFrameworkCore;
using Task.Application.Common.Interfaces;
using Task.Domain;

namespace Task.Persistence;

public class ApplicationContext : DbContext, IApplicationContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Message> Messages { get; set; }
    
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
}