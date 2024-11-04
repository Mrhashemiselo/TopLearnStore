using TopLearn.Core.DTOs.Wallet;
using TopLearn.DataLayer.Entities.Wallet;

namespace TopLearn.Core.Services.Interfaces;
public interface IWalletServices
{
    int BalanceUserWallet(string username);
    List<WalletViewModel> GetWalletUser(string username);
    int ChargeWallet(string username, int amount, string description, bool isPay = false);
    int AddWallet(Wallet wallet);
    Wallet GetWalletByWalletId(int walletId);
    void UpdateWallet(Wallet wallet);
}
