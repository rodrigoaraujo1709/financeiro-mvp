using Microsoft.EntityFrameworkCore;

namespace FinanceiroMVP.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
}