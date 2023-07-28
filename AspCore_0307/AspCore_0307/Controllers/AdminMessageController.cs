using Business_Layer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AspCore_0307.Controllers
{
    public class AdminMessageController : Controller
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EFWriterMessageRepository());
        public IActionResult ReceiverMessageBox()
        {
            string p;
            p = "admin@gmail.com";
            var values = writerMessageManager.TGetListReceiverMessage(p);
            return View(values);
        }
        public IActionResult SendMessageBox()
        {
            string p;
            p = "admin@gmail.com";
            var values = writerMessageManager.TGetListSenderMessage(p);
            return View(values);
        }
        public IActionResult AdminMessageDelete(int id)
        {
            string p;
            p = "admin@gmail.com";
            var values = writerMessageManager.TGetById(id);
            
            if (values.Receiver==p)
            {
                writerMessageManager.TDelete(values);
                return RedirectToAction("ReceiverMessageBox");
            }
            else
            {
                writerMessageManager.TDelete(values);
                return RedirectToAction("SendMessageBox");
            }
        }
        public IActionResult ContactDetails(int id)
        {
            WriterMessage writerMessage = writerMessageManager.TGetById(id);
            List<WriterMessage> messageList = new List<WriterMessage> { writerMessage };
            return View(messageList);
        }
        [HttpGet]
        public IActionResult AdminMessageSend()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminMessageSend(WriterMessage p)
        {
            p.Sender = "admin@gmail.com";
            p.SenderName = "Admin";
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            Context c = new Context();
            var usernamesurname = c.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            p.ReceiverName = usernamesurname;
            writerMessageManager.TAdd(p);
            return RedirectToAction("SendMessageBox");
        }
    }
}
