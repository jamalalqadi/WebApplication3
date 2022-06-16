using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models.Data;
using WebApplication3.Models.Entities;
using WebApplication3.Models.Helper;

namespace WebApplication3.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHost;

        public EmployeeController(AppDbContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Employees.
                                        Include(e => e.City).
                                        Include(e => e.Department).
                                        Include(e => e.Job);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.City)
                .Include(e => e.Department)
                .Include(e => e.Job)
                .Include(e => e.PersonalData)
                .Include(e => e.EmpRoles)
                .ThenInclude(d=>d.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }
        public async Task<IActionResult> Search(string term)

        {
            var resualt= _context.Employees.Include(e => e.City)
                .Include(e => e.Department)
                .Include(e => e.Job)
                .Include(e => e.PersonalData)
                .Include(e => e.EmpRoles)
                .ThenInclude(d => d.Role).Where(b => b.Name.Contains(term) ||
            b.City.Name.Contains(term) || b.Job.Name.Contains(term)).ToList(); ;
                        return  View("Index",resualt);

        }

        // GET: Employee/Create
        public async Task<IActionResult> CreateOrEdit(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(s=>s.Id==id);
            ViewBag.Cities = new SelectList(_context.Cities, "Id", "Name",employee!=null? employee.CityId:0);
            ViewBag.Departments = new SelectList(_context.Departments, "Id", "Name", employee?.DepartmentId);
            ViewBag.Jobs = new SelectList(_context.Jobs, "Id", "Name", employee?.JobId);
            return View(employee);
        }      

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(Employee model)
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
            ViewBag.Cities = new SelectList(_context.Cities, "Id", "FullName", model != null ? model.CityId : 0);
            ViewBag.Departments = new SelectList(_context.Departments, "Id", "Name", model.DepartmentId);
            ViewBag.Jobs = new SelectList(_context.Jobs, "Id", "Name", model?.JobId);
            return View(model);
        }

        // GET: EmployeeController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _context.Employees.FirstOrDefaultAsync(s => s.Id == id);
            if (model != null)
            {
                _context.Remove(model);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Delete  successfully" });
            }
            return Json(new { success = false, message = "Can not Delete " });
        }

        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> EmployeeExists(string Name)
        {
            if (await _context.Employees.AnyAsync(e => e.Name == Name))
            {
                return Json("is Exitsts");
            }
            return Json(true);
        }

        /*--------------------------PersonalData-----------------------------*/
        #region PersonalData

        public async Task<IActionResult> CreateOrEditPersonalData(int id, int EmployeeId)
        {
            if(id>0)
            return View(await _context.PersonalDatas.FirstOrDefaultAsync(s => s.Id == id));
            
            return View(new PersonalData() { EmployeeId =EmployeeId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEditPersonalData(PersonalData model)
        {
            if (ModelState.IsValid)
            {
                if (Request.Form.Files.Count > 0)
                {
                    var file = Request.Form.Files.FirstOrDefault();
                    string pathUpload = Path.Combine(_webHost.WebRootPath, "Uploads");
                    model.ImgUrl = UploadFileHelper.UploadFile(file, pathUpload, model.ImgUrl);
                }
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
                return RedirectToAction(nameof(Details),new {Id=model.EmployeeId });
            }
            TempData["error"] = "error";
            return View(model);
        }


        #endregion
        /*----------------------------------EmpRoles-----------------------------------------*/
        #region EmpRoles
        public async Task<IActionResult> AddEmpRole(int EmployeeId)
        {
            ViewBag.Roles = await _context.Roles.Select(s => new { s.Id, s.Name }).ToListAsync();
            return View(new EmpRole() { EmployeeId = EmployeeId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEmpRole(EmpRole model)
        {
            if (ModelState.IsValid)
            {               
                    TempData["success"] = "Add successfully";
                    _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { Id = model.EmployeeId });
            }
            TempData["error"] = "error";
            ViewBag.Roles = await _context.Roles.Select(s => new { s.Id, s.Name }).ToListAsync();
            return View(model);
        }


        public async Task<IActionResult> DeleteEmpRole(int id)
        {
            var model = await _context.EmpRoles.FirstOrDefaultAsync(s => s.Id == id);
            if (model != null)
            {
                _context.Remove(model);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Delete  successfully" });
            }
            return Json(new { success = false, message = "Can not Delete " });
        }

        #endregion

    }
}
