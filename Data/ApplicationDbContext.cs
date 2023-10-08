using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RazorScaffolding.Training.Models;

namespace RazorScaffolding.Training.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }

    public DbSet<Person> People { get; set; } = default!;
    public DbSet<Purchase> Purchases { get; set; } = default!;
}
