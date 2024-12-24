using Microsoft.EntityFrameworkCore;
using TopLearn.DataLayer.Entities.Users;
using TopLearn.DataLayer.Entities.Wallet;

namespace TopLearn.DataLayer.Context;
public class TopLearnContext : DbContext
{
    public TopLearnContext(DbContextOptions<TopLearnContext> options) : base(options)
    {

    }
    #region User
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    #endregion

    #region Wallet
    public DbSet<WalletType> WalletTypes { get; set; }
    public DbSet<Wallet> Wallets { get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasQueryFilter(u => !u.IsDelete);

        base.OnModelCreating(modelBuilder);
        modelBuilder.Seed();
    }
}
