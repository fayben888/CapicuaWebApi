using Microsoft.EntityFrameworkCore;

public class CapicuaContext:DbContext
{
    public DbSet<Capicua> capicuas { get; set; }

    public CapicuaContext(DbContextOptions<CapicuaContext> options) : base(options)
    {
        
    }

    
}