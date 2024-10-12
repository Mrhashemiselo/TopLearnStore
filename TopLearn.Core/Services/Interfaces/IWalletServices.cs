using TopLearn.Core.DTOs.Wallet;
using TopLearn.DataLayer.Entities.Wallet;

namespace TopLearn.Core.Services.Interfaces;
public interface IWalletServices
{
    int BalanceUserWallet(string username);
    List<WalletViewModel> GetWalletUser(string username);
    void ChargeWallet(string username, int amount, string description, bool isPay = false);
    void AddWallet(Wallet wallet);
}
