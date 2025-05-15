using Microsoft.EntityFrameworkCore;


namespace SSC.Storage;

public class ApplicationContext : DbContext
{
    public DbSet<User> User { get; set; }
    public ApplicationContext()
    {
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Sourse = Storage/DataBase/User.db");
    }
}


