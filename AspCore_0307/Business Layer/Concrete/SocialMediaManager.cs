using Business_Layer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Concrete
{
    public class SocialMediaManager : ISocialMediaService
    {
        ISocialMediaDAL _socialMediaService;

        public SocialMediaManager(ISocialMediaDAL socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        public List<SocialMedia> GetList()
        {
            return _socialMediaService.GetList();
        }

        public void TAdd(SocialMedia t)
        {
            _socialMediaService.Insert(t);
        }

        public void TDelete(SocialMedia t)
        {
            _socialMediaService.Delete(t);
        }

        public SocialMedia TGetById(int id)
        {
            return _socialMediaService.GetByID(id);
        }

        public List<SocialMedia> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public void Update(SocialMedia t)
        {
            _socialMediaService.Update(t);
        }
    }
}
