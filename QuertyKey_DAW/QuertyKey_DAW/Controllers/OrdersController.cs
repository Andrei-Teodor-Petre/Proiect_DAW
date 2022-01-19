using Microsoft.AspNetCore.Mvc;

namespace QuertyKey_DAW.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
