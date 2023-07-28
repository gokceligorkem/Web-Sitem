using Business_Layer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AspCore_0307.ViewComponents.Dashboard
{
    public class ProjeList:ViewComponent

    {
        PortfolioManager portfolioManager = new PortfolioManager(new EFPortfoioRepository());
        public IViewComponentResult Invoke()
        {
            var values = portfolioManager.GetList();
            return View(values);
        }
    }
}
