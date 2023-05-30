using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace webShop.Data;

public class UserDbContext : IdentityDbContext<IdentityUser>
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
        this.Database.EnsureCreated();
    }
}
 