using ASP.app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.app.Controllers
{
    public class PersonController : Controller
    {
        private readonly AppDbContext _context;

        public PersonController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string? message)
        {
            ViewBag.Message = message;
            return View(await _context.People.ToListAsync());
        }

        public IActionResult Create()
        {
            return View("Form", new Person());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { message = "Persona creada exitosamente" });
            }
            return View("Form", person);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var person = await _context.People.FindAsync(id);
            if (person == null) return NotFound();
            return View("Form", person);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Update(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { message = "Persona actualizada exitosamente" });
            }
            return View("Form", person);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var person = await _context.People.FindAsync(id);
            if (person != null)
            {
                _context.People.Remove(person);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index), new { message = "Persona eliminada exitosamente" });
        }
    }
}
