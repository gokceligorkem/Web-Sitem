using Business_Layer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AspCore_0307.ViewComponents.Feature
{
    public class FeaturePage:ViewComponent
    {
        FeatureManager featureManager=new FeatureManager(new EFFeatureRepository() );
        public IViewComponentResult Invoke()
        {
            var values = featureManager.GetList();
            return View(values);
        }
    }
}
