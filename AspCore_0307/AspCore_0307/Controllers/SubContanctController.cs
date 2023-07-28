using Business_Layer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AspCore_0307.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SubContanctController : Controller
    {
        ContactManager contactManager = new ContactManager(new EFContactRepository());
        public IActionResult Index()
        {

            var values = contactManager.TGetById(1);
            return View(values);
        }

        [HttpPost]
        public IActionResult Index(Contact contact)
        {

            contactManager.Update(contact);

            return RedirectToAction("Index", "Default");

        }
    }
}
