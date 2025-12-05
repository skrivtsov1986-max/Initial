using Microsoft.EntityFrameworkCore;
using PlanPkApp.Models;

namespace PlanPkApp.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<PlanPk> PlanPks => Set<PlanPk>();
}
