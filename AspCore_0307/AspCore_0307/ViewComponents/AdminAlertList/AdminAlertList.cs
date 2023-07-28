using Microsoft.AspNetCore.Mvc;

namespace AspCore_0307.ViewComponents.AdminAlertList
{
    public class AdminAlertList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
