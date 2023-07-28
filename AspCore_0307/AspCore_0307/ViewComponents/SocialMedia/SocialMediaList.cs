using Business_Layer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AspCore_0307.ViewComponents.SocialMedia
{
    public class SocialMediaList:ViewComponent
    {
        SocialMediaManager socialMedia = new SocialMediaManager(new EFSocialMediaRepository());

        public IViewComponentResult Invoke()
        {
            var values = socialMedia.GetList();
            return View(values);
        }
    }
}
