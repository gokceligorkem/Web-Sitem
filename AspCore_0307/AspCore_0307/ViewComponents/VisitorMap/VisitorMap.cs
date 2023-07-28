using Microsoft.AspNetCore.Mvc;

namespace AspCore_0307.ViewComponents.VisitorMap
{
    public class VisitorMap : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
  
}
