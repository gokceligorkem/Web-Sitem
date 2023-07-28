using Business_Layer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspCore_0307.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/Message")]
    public class MessageController : Controller
    {
        WriterMessageManager writermessageManager = new WriterMessageManager(new EFWriterMessageRepository());
        private readonly UserManager<WriterUser> _userManager;
       
        public MessageController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        [Route("")]
        [Route("ReceiverList")]
        public async Task<IActionResult> ReceiverList(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messagelist = writermessageManager.TGetListReceiverMessage(p);

            return View(messagelist);
        }
        [Route("")]
        [Route("SenderList")]
        public async Task<IActionResult> SenderList(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messagelist = writermessageManager.TGetListSenderMessage(p);

            return View(messagelist);
        }
        [Route("MessageDetails/{id}")]
        public IActionResult MessageDetails(int id)
        {
            WriterMessage writerMessage = writermessageManager.TGetById(id);
            List<WriterMessage> messageList = new List<WriterMessage> { writerMessage };
            return View(messageList);
        }
        [HttpGet]
        [Route("")]
        [Route("SendMessage")]
        public IActionResult SendMessage()
        {
            List<string> userEmails = _userManager.Users.Select(u => u.Email).ToList();
            ViewBag.UserEmails = userEmails;
            return View();
        }
        [HttpPost]

        [Route("")]
        [Route("SendMessage")]
        public async Task<IActionResult> SendMessage(WriterMessage p)
        {

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = values.Email;
            string name = values.Name + " " + values.Surname;
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.Sender = mail;
            p.SenderName = name;
            Context c = new Context();
            var usernamesurname = c.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            p.ReceiverName = usernamesurname ?? "Unknown";

            writermessageManager.TAdd(p);

            return RedirectToAction("SenderList");

        } 
    }
}
