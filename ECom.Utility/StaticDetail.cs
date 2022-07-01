using Microsoft.AspNetCore.Hosting;

namespace ECom.Utility;

public static class StaticDetail
{
    public const string RoleUser = "User";
    public const string RoleAdmin = "Admin";
    public const string AdminEmail = "admin@ecomweb.com";
    public const string AdminPassword = "Admin123!";
    public static IServiceProvider ServiceProvider;
}