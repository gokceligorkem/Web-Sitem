using Business_Layer.Concrete;
using Business_Layer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;
using X.PagedList;

namespace AspCore_0307.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProjeController : Controller
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EFPortfoioRepository());
        public IActionResult Index(int page=1)
        {
            ViewBag.v1 = "Proje Listesi";
            ViewBag.v2 = "Projeler";
            ViewBag.v3 = "Proje Listesi";
            var values = portfolioManager.GetList().ToPagedList(page, 5) ;
            return View(values);
        }
        [HttpGet]
        public IActionResult AddPortfolio()
        {
            ViewBag.v1 = "Proje Ekleme";
            ViewBag.v2 = "Projeler";
            ViewBag.v3 = "Proje Ekleme";
            return View();
        }
        [HttpPost]
        public IActionResult AddPortfolio(Portfolio p)
        {
            ViewBag.v1 = "Proje Listesi";
            ViewBag.v2 = "Projeler";
            ViewBag.v3 = "Proje Ekleme";
            PortfolioValidator validations = new PortfolioValidator();
            ValidationResult results = validations.Validate(p);
            if (results.IsValid) {
            portfolioManager.TAdd(p);   
            return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
                
            }
            return View();
        }
        public IActionResult RemovePortfolio(int id)
        {
            var values = portfolioManager.TGetById(id);
            portfolioManager.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdatePortfolio(int id)
        {
            ViewBag.v1 = "Güncelle";
            ViewBag.v2 = "Projeler";
            ViewBag.v3 = "Proje Güncelleme";
            var values = portfolioManager.TGetById(id);
            return View(values);

        }
        [HttpPost]
        public IActionResult UpdatePortfolio(Portfolio p)
        {
           PortfolioValidator validations=new PortfolioValidator();
            ValidationResult results = validations.Validate(p); 

            
            if (results.IsValid)
            {
                portfolioManager.Update(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                
            }
            return View();

        }
    }
}
