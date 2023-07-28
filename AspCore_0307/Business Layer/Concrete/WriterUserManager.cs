using Business_Layer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Concrete
{
    public class WriterUserManager : IWriterUserServicess
    {
        IWriterUserDAL _writerUserDal;

        public WriterUserManager(IWriterUserDAL writerUserDal)
        {
            _writerUserDal = writerUserDal;
        }

        public List<WriterUser> GetList()
        {
           return _writerUserDal.GetList();
        }

        public void TAdd(WriterUser t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(WriterUser t)
        {
            throw new NotImplementedException();
        }

        public WriterUser TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<WriterUser> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public void Update(WriterUser t)
        {
            throw new NotImplementedException();
        }
    }
}
