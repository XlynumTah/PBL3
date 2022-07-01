using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ECom.DataAccess.Data;

public class ApplicationDbContextFactory:IDesignTimeDbContextFactory<ApplicationDbContext>

{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer("Server=.;Database=EComWeb;Trusted_Connection=True");
        return new ApplicationDbContext(optionsBuilder.Options);

    }
}