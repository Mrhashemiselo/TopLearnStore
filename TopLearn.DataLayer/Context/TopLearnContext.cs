using Microsoft.EntityFrameworkCore;
using TopLearn.DataLayer.Entities.Course;
using TopLearn.DataLayer.Entities.Permissions;
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

    #region Permission
    public DbSet<Permission> Permission { get; set; }
    public DbSet<RolePermission> RolePermission { get; set; }
    #endregion

    #region Course
    public DbSet<CourseGroup> CourseGroups { get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasQueryFilter(u => !u.IsDelete);

        modelBuilder.Entity<Role>()
            .HasQueryFilter(w => !w.IsDelete);

        modelBuilder.Entity<CourseGroup>()
          .HasQueryFilter(w => !w.IsDelete);

        base.OnModelCreating(modelBuilder);
        modelBuilder.Seed();
    }
}
