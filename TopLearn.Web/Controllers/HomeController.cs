using Microsoft.AspNetCore.Mvc;

namespace TopLearn.Web.Controllers;
public class HomeController : Controller
{
    public IActionResult Index() => View();
}
