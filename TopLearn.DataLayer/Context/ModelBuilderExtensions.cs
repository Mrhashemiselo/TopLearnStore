using Microsoft.EntityFrameworkCore;
using TopLearn.DataLayer.Entities.Wallet;

namespace TopLearn.DataLayer.Context;
public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WalletType>().HasData(
            new WalletType() { Id = 1, Title = "واریز" },
            new WalletType() { Id = 2, Title = "برداشت" }
            );

        modelBuilder.Entity<Wallet>().HasData(
            new Wallet()
            {
                Id = 1,
                WalletTypeId = 1,
                UserId = 12,
                Amount = 2000000,
                Description = "شارژ حساب",
                IsPay = true,
                CreateDate = DateTime.Now
            },
            new Wallet()
            {
                Id = 2,
                WalletTypeId = 1,
                UserId = 12,
                Amount = 500000,
                Description = "شارژ حساب",
                IsPay = true,
                CreateDate = DateTime.Now
            },
            new Wallet()
            {
                Id = 3,
                WalletTypeId = 2,
                UserId = 12,
                Amount = 650000,
                Description = "خرید دوره",
                IsPay = true,
                CreateDate = DateTime.Now
            }
            );
    }

}
