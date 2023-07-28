using Business_Layer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AspCore_0307.ViewComponents.Contact
{
    public class SendMessage:ViewComponent
    {
        MessageManager messageManager = new MessageManager(new EFMessageRepository() );
        [HttpGet]
        public IViewComponentResult Invoke()
        {
            return View();
        }
        //[HttpPost]
        //public IViewComponentResult Invoke(Message m)
        //{
        //    //Gönderim tarihini çekelim
        //    m.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        //    //aktif mesaj
        //    m.Status = true;
        //    messageManager.TAdd(m);
        //    return View();
        //}
    }
}
