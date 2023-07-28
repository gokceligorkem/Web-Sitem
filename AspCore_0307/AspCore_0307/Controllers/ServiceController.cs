using Business_Layer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AspCore_0307.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ServiceController : Controller
    {
        ServiceManager serviceManager = new ServiceManager(new EFServiceRepository());
        public IActionResult Index()
        {
            ViewBag.v1 = "Servis Listesi";
            ViewBag.v2 = "Servisler";
            ViewBag.v3 = "Servis Listesi";
            var values = serviceManager.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddService()
        {
            ViewBag.v1 = "Servis Ekleme";
            ViewBag.v2 = "Servisler";
            ViewBag.v3 = "Servis Listesi";

            return View();
        }
        [HttpPost]
        public IActionResult AddService(Service s)
        {
            serviceManager.TAdd(s);
            return RedirectToAction("Index");
        }
        public IActionResult RemoveService(int id)
        {
            var values = serviceManager.TGetById(id);
            serviceManager.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateService(int id)
        {
            ViewBag.v1 = "Servis Güncelleme";
            ViewBag.v2 = "Servisler";
            ViewBag.v3 = "Servis Güncelleme ";
            var values = serviceManager.TGetById(id);
            return View(values);

        }
        [HttpPost]
        public IActionResult UpdateService(Service S)
        {

            serviceManager.Update(S);

            return RedirectToAction("Index");

        }
    }
}
