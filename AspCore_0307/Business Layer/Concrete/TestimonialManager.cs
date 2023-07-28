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
    public class TestimonialManager : ITestimonialService
    {
        ITestimonialDAL _testimonialDal;

        public TestimonialManager(ITestimonialDAL testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public List<Testimonial> GetList()
        {
            return _testimonialDal.GetList();
        }

        public void TAdd(Testimonial t)
        {
            _testimonialDal.Insert(t);
        }

        public void TDelete(Testimonial t)
        {
            _testimonialDal.Delete(t);
        }

        public Testimonial TGetById(int id)
        {
            return _testimonialDal.GetByID(id);
        }

        public List<Testimonial> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public void Update(Testimonial t)
        {
            _testimonialDal.Update(t);
        }
    }
}
