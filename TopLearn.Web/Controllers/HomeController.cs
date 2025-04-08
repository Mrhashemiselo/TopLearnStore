using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Parbad;
using TopLearn.Core.Services.Interfaces;

namespace TopLearn.Web.Controllers;
public class HomeController(IWalletServices _walletServices,
                            IOnlinePayment onlinePayment,
                            ICourseServices courseServices) : Controller
{

    #region zarinpal fields
    //private readonly Payment _payment;
    //private readonly Authority _authority;
    //private readonly Transactions _transactions;


    //public HomeController()
    //{
    //    #region zarinpal fill fileds
    //    //var expose = new Expose();
    //    //_payment = expose.CreatePayment();
    //    //_authority = expose.CreateAuthority();
    //    //_transactions = expose.CreateTransactions();
    //    #endregion
    //}
    #endregion
    public IActionResult Index() => View();

    [Route("OnlinePayment/{id}")]
    public async Task<IActionResult> OnlinePayment(int id)
    {
        var wallet = _walletServices.GetWalletByWalletId(id);
        var invoice = await onlinePayment.FetchAsync();

        if (invoice.Status != PaymentFetchResultStatus.ReadyForVerifying)
        {
            var isAlreadyVerified = invoice.IsAlreadyVerified;

            ViewBag.IsSuccess = false;
        }

        var verifyResult = await onlinePayment.VerifyAsync(invoice);

        if (verifyResult.Status == PaymentVerifyResultStatus.Succeed)
        {
            ViewBag.Code = verifyResult.TrackingNumber;
            ViewBag.IsSuccess = true;
            wallet.IsPay = true;
            _walletServices.UpdateWallet(wallet);
        }

        return View(verifyResult);
    }

    [Route("home/GetSubGroups/{id}")]
    public IActionResult GetSubGroups(int id)
    {
        List<SelectListItem> listItems = new()
        {
            new SelectListItem()
            {
                Text = "انتخاب کنید",
                Value = ""
            }
        };
        var subGroups = courseServices.GetSubGroupForManageCourse(id);
        listItems.AddRange(subGroups);
        return Json(new SelectList(listItems, "Value", "Text"));
    }
}
