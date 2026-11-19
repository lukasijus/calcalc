using Microsoft.EntityFrameworkCore; 
using calcalc.api.entities;

namespace calcalc.api.Data; 

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
	{

	}

	public DbSet<User> Users => Set<User>();
}
