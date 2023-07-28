using Business_Layer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AspCore_0307.Areas.Writer.ViewComponents
{
    public class Notification:ViewComponent
    {
        AnnouncementManager announcementManager = new AnnouncementManager(new EFAnnouncementRepository());

        public IViewComponentResult Invoke()
        {
            var values = announcementManager.GetList().Take(3).ToList();
            return View(values);
        }
    }
}
