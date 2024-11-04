using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Parbad;
using Parbad.AspNetCore;
using Parbad.Gateway.ZarinPal;
using TopLearn.Core.Services.Interfaces;
using TopLearn.Web.Parbad.ViewModels;

namespace TopLearn.Web.Areas.UserPanel.Controllers;
[Area("UserPanel")]
[Authorize]
public class WalletController : Controller
{
    private readonly IWalletServices _walletServices;
    private readonly IUserServices _userServices;

    private readonly IOnlinePayment _onlinePayment;

    public WalletController(IWalletServices walletServices,
        IUserServices userServices,
        IOnlinePayment onlinePayment)
    {
        _walletServices = walletServices;
        _userServices = userServices;
        _onlinePayment = onlinePayment;
    }


    [Route("UserPanel/Wallet")]
    public IActionResult Index()
    {
        ViewBag.ListWallet = _walletServices.GetWalletUser(User.Identity.Name);
        return View();
    }

    [Route("UserPanel/Wallet")]
    [HttpPost]
    public async Task<IActionResult> Index(PayViewModel model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.ListWallet = _walletServices.GetWalletUser(User.Identity.Name);
            return View();
        }

        var walletId = _walletServices.ChargeWallet(User.Identity.Name, (int)model.Amount, "شارژ حساب");

        #region Parpad payment
        var callbackUrl = $"https://localhost:7207/onlinePayment/{walletId}";
        var result = await _onlinePayment.RequestAsync(invoice =>
        {
            invoice.SetZarinPalData("Description")
                   .SetCallbackUrl(callbackUrl)
                   .SetAmount(model.Amount)
                   .SetGateway(model.SelectedGateway.ToString());

            if (model.GenerateTrackingNumberAutomatically)
            {
                invoice.UseAutoIncrementTrackingNumber();
            }
            else
            {
                invoice.SetTrackingNumber(model.TrackingNumber);
            }
        });

        if (result.IsSucceed)
        {
            return result.GatewayTransporter.TransportToGateway();
        }
        #endregion

        return View("PayRequestError", result);
    }
}
