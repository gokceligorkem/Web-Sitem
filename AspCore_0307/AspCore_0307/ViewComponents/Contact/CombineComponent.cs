using Microsoft.AspNetCore.Mvc;

namespace AspCore_0307.ViewComponents.Contact
{
    public class CombineComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
