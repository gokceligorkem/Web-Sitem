using Business_Layer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AspCore_0307.ViewComponents.Dashboard
{
    public class ToDoListDashBoard : ViewComponent
    {
        ToDoListManager toDoListManager = new ToDoListManager(new EFToDoListRepository());
        public IViewComponentResult Invoke()
        {
            
            var values = toDoListManager.GetList();

            return View(values);
        }
        
    }
   
}
