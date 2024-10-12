using TopLearn.Core.DTOs.Wallet;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayer.Context;
using TopLearn.DataLayer.Entities.Wallet;

namespace TopLearn.Core.Services.Implement;
public class WalletServices(IUserServices userServices,
    TopLearnContext context) : IWalletServices
{
    public void AddWallet(Wallet wallet)
    {
        context.Wallets.Add(wallet);
        context.SaveChanges();
    }

    public int BalanceUserWallet(string username)
    {
        var userId = userServices.GetUserIdByUsername(username);
        //واریز
        var deposit = context.Wallets
            .Where(a => a.UserId == userId && a.WalletTypeId == 1 && a.IsPay)
            .Select(s => s.Amount)
            .ToList();
        //برداشت
        var withdrawal = context.Wallets
            .Where(a => a.UserId == userId && a.WalletTypeId == 2 && a.IsPay)
            .Select(s => s.Amount)
            .ToList();

        return (deposit.Sum() - withdrawal.Sum());
    }

    public void ChargeWallet(string username, int amount, string description, bool isPay = false)
    {
        Wallet wallet = new()
        {
            Amount = amount,
            Description = description,
            CreateDate = DateTime.Now,
            IsPay = isPay,
            WalletTypeId = 1,
            UserId = userServices.GetUserIdByUsername(username)
        };
        AddWallet(wallet);
    }

    public List<WalletViewModel> GetWalletUser(string username)
    {
        int userId = userServices.GetUserIdByUsername(username);
        return context.Wallets
            .Where(w => w.IsPay && w.UserId == userId)
            .Select(a => new WalletViewModel()
            {
                Type = a.WalletTypeId,
                Amount = a.Amount,
                Description = a.Description,
                DateAndTime = a.CreateDate
            }).ToList();
    }
}
