using Business_Layer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AspCore_0307.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HeaderController : Controller
    {FeatureManager featureManager=new FeatureManager(new EFFeatureRepository());
        public IActionResult Index()
        {
           
            var values = featureManager.TGetById(1);
            return View(values);
        }
        
        [HttpPost]
        public IActionResult UpdateFeature(Feature f)
        {

            featureManager.Update(f);

            return RedirectToAction("Index","Default");

        }
    }
}
