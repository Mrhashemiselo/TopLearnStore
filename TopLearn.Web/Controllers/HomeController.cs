using Microsoft.AspNetCore.Mvc;
using Parbad;
using TopLearn.Core.Services.Interfaces;

namespace TopLearn.Web.Controllers;
public class HomeController : Controller
{
    private readonly IWalletServices _walletServices;

    #region zarinpal fields
    //private readonly Payment _payment;
    //private readonly Authority _authority;
    //private readonly Transactions _transactions;
    #endregion

    private readonly IOnlinePayment _onlinePayment;

    public HomeController(IWalletServices walletServices,
                          IOnlinePayment onlinePayment)
    {
        _walletServices = walletServices;
        _onlinePayment = onlinePayment;

        #region zarinpal fill fileds
        //var expose = new Expose();
        //_payment = expose.CreatePayment();
        //_authority = expose.CreateAuthority();
        //_transactions = expose.CreateTransactions();
        #endregion
    }

    public IActionResult Index() => View();

    [Route("OnlinePayment/{id}")]
    public async Task<IActionResult> OnlinePayment(int id)
    {
        var wallet = _walletServices.GetWalletByWalletId(id);
        var invoice = await _onlinePayment.FetchAsync();

        if (invoice.Status != PaymentFetchResultStatus.ReadyForVerifying)
        {
            var isAlreadyVerified = invoice.IsAlreadyVerified;

            ViewBag.IsSuccess = false;
        }

        var verifyResult = await _onlinePayment.VerifyAsync(invoice);

        if (verifyResult.Status == PaymentVerifyResultStatus.Succeed)
        {
            ViewBag.Code = verifyResult.TrackingNumber;
            ViewBag.IsSuccess = true;
            wallet.IsPay = true;
            _walletServices.UpdateWallet(wallet);
        }

        return View(verifyResult);
    }
}
