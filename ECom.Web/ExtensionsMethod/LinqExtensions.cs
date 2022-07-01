using ECom.Models;
using Microsoft.EntityFrameworkCore;

namespace ECom.Web.ExtensionsMethod;

public static class LinqExtensions
{
    public static IQueryable<Product> GetAllAvailbleProduct(this DbSet<Product> dbSet)
    {
        return dbSet.Where(p => p.IsDeleted == false).Where(p => p.Quantity > 0);
    }
}