using Business_Layer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspCore_0307.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminContactController : Controller
    {
        MessageManager messageManager = new MessageManager(new EFMessageRepository());    
        public IActionResult Index()
        {
            var values = messageManager.GetList();
            return View(values);
        }
        public IActionResult DeleteContact(int id)
        {
            var values = messageManager.TGetById(id);
            messageManager.TDelete(values);
            return RedirectToAction("Index");
        }
        public IActionResult ContactDetails(int id)
        {
            var values = messageManager.TGetById(id);
            return View(values);
        }
    }
}
