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
    public class MessageManager : IMessageService
    {
        IMessageDAL _messageDAL;

        public MessageManager(IMessageDAL messageDAL)
        {
            _messageDAL = messageDAL;
        }

        public List<Message> GetList()
        {
            return _messageDAL.GetList();
        }

        public void TAdd(Message t)
        {
            _messageDAL.Insert(t);
        }

        public void TDelete(Message t)
        {
            _messageDAL.Delete(t);
        }

        public Message TGetById(int id)
        {
            return _messageDAL.GetByID(id);
        }

        public List<Message> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public void Update(Message t)
        {
            throw new NotImplementedException();
        }
    }
}
