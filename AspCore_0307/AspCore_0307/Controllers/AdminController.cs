using Microsoft.AspNetCore.Mvc;

namespace AspCore_0307.Controllers
{
    public class AdminController : Controller
    {
        public PartialViewResult PartialSlideBar()
        {
            return PartialView();
        }
        public PartialViewResult PartialFooter() { return PartialView(); }
        public PartialViewResult PartialNavbar() { return PartialView(); }
        public PartialViewResult PartialHead() { return PartialView(); }
        public PartialViewResult PartialScript() { return PartialView(); }
        public PartialViewResult NavigationPartial() { return PartialView(); }
        public PartialViewResult NewSidebar() { return PartialView(); }
    }
}
