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
    public class ExperienceManager : IExperienceService
    {
        IExperienceDAL _experienceDal;

        public ExperienceManager(IExperienceDAL experienceDal)
        {
            _experienceDal = experienceDal;
        }

        public List<Experience> GetList()
        {
            return _experienceDal.GetList();
        }

        public void TAdd(Experience t)
        {
            _experienceDal.Insert(t);
        }

        public void TDelete(Experience t)
        {
            _experienceDal.Delete(t);
        }

        public Experience TGetById(int id)
        {
            return _experienceDal.GetByID(id);
        }

        public List<Experience> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public void Update(Experience t)
        {
            _experienceDal.Update(t);
        }
    }
}
