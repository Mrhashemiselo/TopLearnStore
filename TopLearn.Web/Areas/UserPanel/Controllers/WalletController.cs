using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TopLearn.Core.DTOs.Wallet;
using TopLearn.Core.Services.Interfaces;

namespace TopLearn.Web.Areas.UserPanel.Controllers;
[Area("UserPanel")]
[Authorize]
public class WalletController(IWalletServices walletServices) : Controller
{
    [Route("UserPanel/Wallet")]
    public IActionResult Index()
    {
        ViewBag.ListWallet = walletServices.GetWalletUser(User.Identity.Name);
        return View();
    }

    [Route("UserPanel/Wallet")]
    [HttpPost]
    public IActionResult Index(ChargeWalletViewModel model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.ListWallet = walletServices.GetWalletUser(User.Identity.Name);
            return View();
        }

        walletServices.ChargeWallet(User.Identity.Name, model.Amount, "شارژ حساب");

        //TODO: online payment
        return null;
    }
}
