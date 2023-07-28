using AspCore_Api.DataAccessLayer_DAL_.ApiContext;
using AspCore_Api.DataAccessLayer_DAL_.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspCore_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult CategoryList()
        {
            var c=new Context();
            return Ok(c.Categories.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            using var c=new Context();
            var values=c.Categories.Find(id);
            if (values == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(values);
            }
           
        }
        [HttpPost]
        public IActionResult AddCategory(Category p)
        {
            using var c = new Context();
            c.Categories.Add(p);
            c.SaveChanges();
            return Created("", p);
        }
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            using var c=new Context();
            var values = c.Categories.Find(id);
            if (values == null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(values);
                c.SaveChanges();
                return NoContent();
            }   
        }
        [HttpPut]
        public IActionResult UpdateCategory(Category p)
        {
            using var c = new Context();
            var values = c.Find<Category>(p.CategoryID);
            if (values == null)
            {
                return NotFound();
            }
            else
            {
                values.CategoryName = p.CategoryName;
                c.Update(values);
                c.SaveChanges();
                return NoContent();
            }
        }
    }
}
