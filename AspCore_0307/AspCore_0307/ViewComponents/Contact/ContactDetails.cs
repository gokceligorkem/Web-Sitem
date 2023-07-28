using Business_Layer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AspCore_0307.ViewComponents.Contact
{
    public class ContactDetails:ViewComponent
    {
        ContactManager contactManager = new ContactManager(new EFContactRepository());
        public IViewComponentResult Invoke()
        {
            var values = contactManager.GetList();
            return View(values);
        }
    }
}
