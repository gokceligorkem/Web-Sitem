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
    public class ServiceManager : IServiceService
    {
        IServiceDAL _serviceDAL;

        public ServiceManager(IServiceDAL serviceDAL)
        {
            _serviceDAL = serviceDAL;
        }

        public List<Service> GetList()
        {
           return _serviceDAL.GetList();
        }

        public void TAdd(Service t)
        {
            _serviceDAL.Insert(t);
        }

        public void TDelete(Service t)
        {
            _serviceDAL.Delete(t);
        }

        public Service TGetById(int id)
        {
            return _serviceDAL.GetByID(id);
        }

        public List<Service> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public void Update(Service t)
        {
            _serviceDAL.Update(t);
        }
    }
}
