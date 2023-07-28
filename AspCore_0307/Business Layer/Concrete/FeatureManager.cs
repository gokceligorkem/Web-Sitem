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
    public class FeatureManager :IGenericService<Feature>
    {
        IFeatureDAL _featureDal;

        public FeatureManager(IFeatureDAL featureDal)
        {
            _featureDal = featureDal;
        }

        public List<Feature> GetList()
        {
             return _featureDal.GetList();
        }

        public void TAdd(Feature t)
        {
            _featureDal.Insert(t);
        }

        public void TDelete(Feature t)
        {
            _featureDal.Delete(t);
        }

        public Feature TGetById(int id)
        {
             return _featureDal.GetByID(id);
        }

        public List<Feature> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public void Update(Feature t)
        {
            _featureDal.Update(t);
        }
    }
}
