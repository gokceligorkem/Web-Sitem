using Business_Layer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AspCore_0307.ViewComponents.Dashboard
{
    public class AdminNavbarMessageList:ViewComponent
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EFWriterMessageRepository());
        public IViewComponentResult Invoke()
        {
            string p = "admin@gmail.com";
            Context c = new Context();
            
            var img1 = c.WriterMessages.Where(x => x.Receiver == p).Select(z => z.Sender).FirstOrDefault();

            var img2 = c.Users.Where(x => x.Email == img1).Select(z => z.ImageUrl).FirstOrDefault();

            ViewBag.v1 = img2;
            
            var values = writerMessageManager.TGetListReceiverMessage(p).OrderByDescending(x=>x.WriterMessageID).Take(3).ToList();
            return View(values);
        }
    }
}
