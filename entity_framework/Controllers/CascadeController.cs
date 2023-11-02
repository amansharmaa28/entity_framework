
using entity_framework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace entity_framework.Controllers
{
    public class CascadeController : Controller
    {
        private readonly EmpDbContext context;

        public CascadeController(EmpDbContext context)
        {
            this.context = context;
        }

        public JsonResult Country()
        {
            var cnt=context.Countries.ToList();
            return new JsonResult(cnt);
        }

        public JsonResult State(int id)
        {
            var st = context.states.Where(e=>e.Country.Id == id).ToList();
            return new JsonResult(st);
        }
            public JsonResult City (int id)
        {
            var ct = context.City.Where(e => e.State.Id == id).ToList();
            return new JsonResult(ct);
        }

        public IActionResult CascadeDropdown() 
        {

            return View();     
        }

        
    }
}
