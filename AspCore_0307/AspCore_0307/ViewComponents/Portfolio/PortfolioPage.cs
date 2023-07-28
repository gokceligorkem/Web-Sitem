using Business_Layer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AspCore_0307.ViewComponents.Portfolio
{
    public class PortfolioPage:ViewComponent
    {
        PortfolioManager portFoliomanager = new PortfolioManager(new EFPortfoioRepository());
        public IViewComponentResult Invoke()
        {
            var values = portFoliomanager.GetList();
            return View(values);
        }
    }
}
