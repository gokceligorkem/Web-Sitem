using Business_Layer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AspCore_0307.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        

        public IActionResult Index()
        {
            return View();
        }
        
    }
}
