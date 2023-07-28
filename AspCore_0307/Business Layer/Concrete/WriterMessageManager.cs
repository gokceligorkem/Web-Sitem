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
    public class WriterMessageManager : IWriterMessageService
    {
        IWriterMessageDAL _writerMessageDAL;

        public WriterMessageManager(IWriterMessageDAL writerMessageDAL)
        {
            _writerMessageDAL = writerMessageDAL;
        }

        public List<WriterMessage> GetList()
        {
            throw new NotImplementedException();

        }

        public void TAdd(WriterMessage t)
        {
            _writerMessageDAL.Insert(t);
        }

        public void TDelete(WriterMessage t)
        {
            _writerMessageDAL.Delete(t);
        }

        public WriterMessage TGetById(int id)
        {
            return _writerMessageDAL.GetByID(id);
        }

        public List<WriterMessage> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public List<WriterMessage> TGetListReceiverMessage(string p)
        {
            return _writerMessageDAL.GetbyFilter(x => x.Receiver == p);

        }

        public List<WriterMessage> TGetListSenderMessage(string p)
        {
            return _writerMessageDAL.GetbyFilter(x => x.Sender == p);
        }

        public void Update(WriterMessage t)
        {
            throw new NotImplementedException();
        }
    }
}
