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
    public class ToDoListManager : IToDoListService
    {
        IToDoListDAL _todoListDAL;

        public ToDoListManager(IToDoListDAL todoListDAL)
        {
            _todoListDAL = todoListDAL;
        }

        public List<ToDoList> GetList()
        {
            return _todoListDAL.GetList();
        }

        public void TAdd(ToDoList t)
        {
            _todoListDAL.Insert(t);
        }

        public void TDelete(ToDoList t)
        {
            _todoListDAL.Delete(t);
        }

        public ToDoList TGetById(int id)
        {
            return _todoListDAL.GetByID(id);
        }

        public List<ToDoList> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public void Update(ToDoList t)
        {
            _todoListDAL.Update(t);
        }
    }
}
