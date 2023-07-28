using Business_Layer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AspCore_0307.ViewComponents.Portfolio
{
    public class SlidBarDashboard : ViewComponent
    {
        PortfolioManager portFoliomanager = new PortfolioManager(new EFPortfoioRepository());
        public IViewComponentResult Invoke()
        {
            var values = portFoliomanager.GetList();
            return View(values);
        }
    }
  
}
