using entity_framework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace entity_framework.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmpDbContext empDb;

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(EmpDbContext empDb)
        {
            this.empDb = empDb;
        }

        public async Task<IActionResult> Index()
        {
            var UData = await empDb.emps.ToListAsync();
            return View(UData);
        }

        public async Task<IActionResult> first()
        {
            var UData = await empDb.emps.ToListAsync();
            return View(UData);
        }
        public async Task<IActionResult> AGGrid()
        {
            var UData = await empDb.emps.ToListAsync();
            return View(UData);
        }


        public async Task<IActionResult> listview()
        {
            var UData = await empDb.emps.ToListAsync();
            return View(UData);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Emp e)
        {
            if (ModelState.IsValid)
            {
                await empDb.emps.AddAsync(e);
                await empDb.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(e);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || empDb.emps == null)
            {
                return NotFound();
            }
            var UData = await empDb.emps.FirstOrDefaultAsync(x => x.id == id);
            if (UData == null)
            {
                return NotFound();
            }
            return View(UData);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || empDb.emps == null)
            {
                return NotFound();
            }
            var UData = await empDb.emps.FindAsync(id);
            if (UData == null)
            {
                return NotFound();
            }

            return View(UData);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, Emp e)
        {
            if (id != e.id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                empDb.emps.Update(e);
                await empDb.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(e);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || empDb.emps == null)
            {
                return NotFound();
            }
            var UData = await empDb.emps.FirstOrDefaultAsync(x => x.id == id);
            if (UData == null)
            {
                return NotFound();
            }
            return View(UData);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var UData = await empDb.emps.FindAsync(id);
            if (UData != null)
            {
                empDb.emps.Remove(UData);
            }
            await empDb.SaveChangesAsync();
            return RedirectToAction("Index", "Home");



        }
        [HttpPost]
        public IActionResult Up([FromBody] Emp emp)
        {
            if (emp == null)
            {
                return BadRequest("Invalid data received from the client.");
            }
            var updateStudent = empDb.emps.Find(emp.id);

            if (updateStudent == null)
            {
                return NotFound(",employee not found.");
            }
            updateStudent.name = emp.name;
            updateStudent.city = emp.city;
            updateStudent.age = emp.age;
            updateStudent.price = emp.price;
            empDb.SaveChanges();

            return RedirectToAction("Index");

        }
        [HttpPost]

        public IActionResult DeleteData(int? id)
        {
            var emp = empDb.emps.Find(id);

            if (emp == null)
            {
                empDb.emps.Remove(emp);
                empDb.SaveChangesAsync();
                return Json(new { success = true });
            }
            return Json(new { success = false });

        }
        [HttpPost]
        public async Task<IActionResult> Update(Emp updateDetailRequest)
        {
            if (ModelState.IsValid)
            {
                var registration = await empDb.emps.FirstOrDefaultAsync(x => x.id == updateDetailRequest.id);

                if (registration != null)
                {
                    // Update the fields based on the updateDetailRequest

                    registration.id = updateDetailRequest.id;
                    registration.name = updateDetailRequest.name;
                    registration.age = updateDetailRequest.age;
                    registration.city = updateDetailRequest.city;
                    registration.price = updateDetailRequest.price;


                    await empDb.SaveChangesAsync();
                    return Json(new { success = true });
                }
            }

            return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors) });
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            var registration = await empDb.emps.FindAsync(id);

            if (registration != null)
            {
                empDb.emps.Remove(registration);
                await empDb.SaveChangesAsync();
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }


        [HttpGet]
        public IActionResult JSGrid()
        {
            var listOfEmployees = empDb.emps.ToList();

            return View(listOfEmployees);

        }

        [HttpPost]

        public IActionResult JSGrid(int id)
        {
            var listOfEmloyees = empDb.emps.ToList();
            return View(listOfEmloyees);
        }



        [HttpGet]
        public IActionResult GetDetails()
        {
            var addDetails = empDb.emps.ToList();
            return Json(addDetails);

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}