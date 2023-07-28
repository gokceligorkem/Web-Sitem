using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Abstract
{
    public interface IGenericService<T>
    {
        void TAdd(T t);
        void TDelete(T t);
        void Update (T t);
        List<T> GetList();
        T TGetById(int id);
        List<T> TGetListByFilter();
    }
}
