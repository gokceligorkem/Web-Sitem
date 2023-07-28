using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDAL<T> where T : class
    {
        

        public void Delete(T t)
        {
            using var d = new Context();//Using ile bellekte yer tutmaz.Kullanıldıkça çalışır.
            d.Remove(t);//değeri kaldır.
            d.SaveChanges();//veri tabanına kaydet
        }

        public List<T> GetbyFilter(Expression<Func<T, bool>> filter)
        {
            using var c = new Context();
            return c.Set<T>().Where(filter).ToList();
        }

        public T GetByID(int id)
        {
            using var d = new Context();
            return d.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            using var d = new Context();
            return d.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            using var d = new Context();
            d.Add(t);
            d.SaveChanges();
        }

        public void Update(T t)
        {
            using var d = new Context();
            d.Update(t);
            d.SaveChanges();
        }
    }
}
