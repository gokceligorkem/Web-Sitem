using Business_Layer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;

namespace Business_Layer.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDAL _aboutDal;

        public AboutManager(IAboutDAL about)
        {
            _aboutDal = about;
        }

        public List<About> GetList()
        {
           return _aboutDal.GetList();
        }

        public void TAdd(About t)
        {
            _aboutDal.Insert(t);

        }

        public void TDelete(About t)
        {
            _aboutDal.Delete(t);

        }

        public About TGetById(int id)
        {
            return _aboutDal.GetByID(id);
        }

        public List<About> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public void Update(About t)
        {
                _aboutDal.Update(t);
        }
    }
}
