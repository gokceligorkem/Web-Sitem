using Business_Layer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace Business_Layer.Concrete
{
    public class AnnouncementManager : IAnnouncementService
    {
        IAnnouncementDAL _announcementDal;

        public AnnouncementManager(IAnnouncementDAL announcementDal)
        {
            _announcementDal = announcementDal;
        }

        public List<Announcement> GetList()
        {
            return _announcementDal.GetList();
        }

        public void TAdd(Announcement t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Announcement t)
        {
            throw new NotImplementedException();
        }

        public Announcement TGetById(int id)
        {
            return _announcementDal.GetByID(id);
        }

        public List<Announcement> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public void Update(Announcement t)
        {
            throw new NotImplementedException();
        }
    }
}
