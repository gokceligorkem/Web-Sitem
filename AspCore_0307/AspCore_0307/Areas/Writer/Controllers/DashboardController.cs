using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace AspCore_0307.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class DashboardController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public DashboardController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()    
        {

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v=values.Name+" "+values.Surname;

            //Weather APi
            

            string api = "13531686f7c540fc0cec799e4f9431ec";

            string connection = "http://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document=XDocument .Load(connection);
            ViewBag.v5 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            Context c = new Context();
            ViewBag.v1 = c.WriterMessages.Where(x=>x.Receiver==values.Email).Count();
            ViewBag.v2 = c.Announcements.Count() ;
            ViewBag.v3 = c.Users.Count() ;
            ViewBag.v4 = c.Skills.Count();
            return View();
        }
    }
}
