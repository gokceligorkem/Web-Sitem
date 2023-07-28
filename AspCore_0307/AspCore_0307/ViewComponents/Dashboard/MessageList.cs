using AspCore_0307.Areas.Writer.Models;
using Business_Layer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspCore_0307.ViewComponents.Dashboard
{
    public class MessageList:ViewComponent
    {
        private readonly UserManager <WriterUser> _userManager;

        public MessageList(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                
                return View(new List<UserImageMessageModel>());
            }

            using (var context = new Context())
            {
                var list = (from x in context.Users
                            join y in context.Messages
                            on x.Email equals y.Mail
                            select new UserImageMessageModel
                            {
                                ImgUrl=x.ImageUrl,
                                Date=y.Date,
                                SenderName=y.Name,
                                MessageContent=y.Content,
                                Id=y.MessageId
                            }).OrderByDescending(x => x.Id).Take(4).ToList();

                return View(list);
            }
        }
    }
}
