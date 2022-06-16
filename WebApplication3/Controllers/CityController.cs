using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models.Data;
using WebApplication3.Models.Entities;

namespace WebApplication3.Controllers
{
    public class CityController : Controller
    {
        private readonly AppDbContext _context;

        public CityController(AppDbContext context)
        {
            _context = context;
        }

        // GET: City
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cities.ToListAsync());
        }

        // GET: City/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.Cities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // GET: City/Create

        public async Task<IActionResult> CreateOrEdit(int id)
        {
            var employee = await _context.Cities.FirstOrDefaultAsync(s => s.Id == id);
          
            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(City model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id > 0)
                {
                    _context.Update(model);
                    TempData["success"] = "Edit successfully";
                }
                else
                {
                    TempData["success"] = "Add successfully";
                    _context.Add(model);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "error";
        
            return View(model);
        }
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: City/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name")] City city)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(city);
        //        await _context.SaveChangesAsync();
        //        TempData["success"] = "Edit successfully";
        //        return RedirectToAction(nameof(Index));
        //    }
        //    TempData["error"] = "Edit error";
        //    return View(city);
        //}

        //// GET: City/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var city = await _context.Cities.FindAsync(id);
        //    if (city == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(city);
        //}

        //// POST: City/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] City city)
        //{
        //    if (id != city.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(city);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
                   
                   
        //        }
        //        TempData["success"] = "Edit successfully";
        //        return RedirectToAction(nameof(Index));
        //    }
        //    TempData["error"] = "Edit error";
        //    return View(city);
        //}

        // GET: City/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _context.Cities.FirstOrDefaultAsync(s => s.Id == id);
            if (model != null)
            {
                _context.Remove(model);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Delete  successfully" });
            }
            return Json(new { success = false, message = "Can not Delete " });
        }

        // POST: City/Delete/5

        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> CityExists(string Name)
        {
            if (await _context.Cities.AnyAsync(e => e.Name == Name))
            {
               return Json("Exitsts");
            }
            return Json(true);
        }
    }
}
