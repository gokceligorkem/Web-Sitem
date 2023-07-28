using Business_Layer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Concrete
{
    public class PortfolioManager : IWriterUserService
    {
        IPortfolioDAL _portfoliaDal;

        public PortfolioManager(IPortfolioDAL portfoliaDal)
        {
            _portfoliaDal = portfoliaDal;
        }

        public List<Portfolio> GetList()
        {
            return _portfoliaDal.GetList();
        }

        public void TAdd(Portfolio t)
        {
            _portfoliaDal.Insert(t);
        }

        public void TDelete(Portfolio t)
        {
            _portfoliaDal.Delete(t);
        }

        public Portfolio TGetById(int id)
        {
            return _portfoliaDal.GetByID(id);
        }

        public List<Portfolio> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public void Update(Portfolio t)
        {
            _portfoliaDal.Update(t);
        }
    }
}
