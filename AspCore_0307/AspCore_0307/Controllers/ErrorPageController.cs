using Microsoft.AspNetCore.Mvc;

namespace AspCore_0307.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Error404()
        {
            return View();
        }

    }
}
