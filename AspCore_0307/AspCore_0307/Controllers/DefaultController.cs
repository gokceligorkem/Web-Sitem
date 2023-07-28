using Business_Layer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspCore_0307.Controllers
{
    [AllowAnonymous ]
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public PartialViewResult HeaderPartial()
        {
            
            return HeaderPartial();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public PartialViewResult NavbarPartial()
        {
            return NavbarPartial();
        }
        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }
       
        [HttpPost]
        public IActionResult SendMessage(Message p)
        {
            MessageManager messageManager = new MessageManager(new EFMessageRepository());
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.Status = true;
            messageManager.TAdd(p);
           
            return RedirectToAction("Index", "Default");
        }

    }
}
