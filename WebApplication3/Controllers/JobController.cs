using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models.Data;
using WebApplication3.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication3.Controllers
{
    public class JobController : Controller
    {
        private readonly AppDbContext _context;

        public JobController(AppDbContext context)
        {
            _context = context;
        }
        // GET: JobController
        public async Task<IActionResult> Index()
        {
            return View(await _context.Jobs.ToListAsync());
        }

        // GET: JobController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View( await _context.Jobs.FirstOrDefaultAsync(s=>s.Id== id));
        }
        [Authorize(Roles = "Admin")]

        // GET: JobController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Job model)
        {
            if (ModelState.IsValid)
            {
                await _context.AddAsync(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }            
            return View(model);
        }

        [Authorize(Roles = "jamal")]

        // GET: JobController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View("Create",await _context.Jobs.FindAsync(id));
        }

        // POST: JobController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Job model)
        {
            if (ModelState.IsValid)
            {
                 _context.Update(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);

        }
        [Authorize(Roles = "jamal")]

        // GET: JobController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _context.Jobs.FirstOrDefaultAsync(s=>s.Id==id);
            if (model != null)
            {
                _context.Remove(model);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Delete Job successfully" });
            }
            return Json(new { success = false, message = "Can not Delete Job" });
        }

        
    }
}
