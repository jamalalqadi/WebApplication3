using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.ViewModels.Identity;

namespace WebApplication3.Controllers
{
   // [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.Select(user => new UserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                NameRoles = _userManager.GetRolesAsync(user).Result
            }).ToListAsync();

            return View(users);
        }
        public async Task<IActionResult> Add()
        {

            var roles = await _roleManager.Roles.Select(r => new RoleViewModel{RoleId = r.Id,RoleName = r.Name}).ToListAsync();
            var viewModel = new AddUserViewModel
            {
                Roles = roles
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddUserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            
                if (!model.Roles.Any(s => s.IsSelected))
                {
                    ModelState.AddModelError("Roles", "Please select at least one role");
                    return View(model);
                }

                if (await _userManager.FindByEmailAsync(model.Email) != null)
                {
                    ModelState.AddModelError("Email", "Email is already exsts");
                    return View(model);
                }
                if (await _userManager.FindByNameAsync(model.UserName) != null)
                {
                    ModelState.AddModelError("UserName", "UserName is already exsts");
                    return View(model);
                }
                var user = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    FristName = model.FristName,
                    LastName = model.LastName
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("Roles", error.Description);
                        return View(model);
                    }
                }
                await _userManager.AddToRolesAsync(user, model.Roles.Where(s => s.IsSelected).Select(s => s.RoleName));
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Update(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return NotFound();

            var roles = await _roleManager.Roles.ToListAsync();

            var viewModel = new UserViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Roles = roles.Select(role => new RoleViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    IsSelected = _userManager.IsInRoleAsync(user, role.Name).Result
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UserViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);

            if (user == null)
                return NotFound();
            var userWithSameEmail = await _userManager.FindByEmailAsync(model.Email);
            if (userWithSameEmail!=null && userWithSameEmail.Id!= model.Id)
            {
                ModelState.AddModelError("Email", "this Email is already assiged to another user");
                return View(model);
            }
            var userWithSameUserName = await _userManager.FindByNameAsync(model.UserName);
            if (userWithSameUserName != null && userWithSameUserName.Id != model.Id)
            {
                ModelState.AddModelError("UserName", "this UserName is already assiged to another user");
                return View(model);
            }
            user.Email = model.Email;
            user.UserName = model.UserName;
            await _userManager.UpdateAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var role in model.Roles)
            {
                if (userRoles.Any(r => r == role.RoleName) && !role.IsSelected)
                    await _userManager.RemoveFromRoleAsync(user, role.RoleName);

                if (!userRoles.Any(r => r == role.RoleName) && role.IsSelected)
                    await _userManager.AddToRoleAsync(user, role.RoleName);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return NotFound();

            var result= await _userManager.DeleteAsync(user);
            if(!result.Succeeded)
                return Json(new { success = false, message = "Can not Delete User" });

            return Json(new { success = true, message = "Job Delete successfully" });
        }

    }
}