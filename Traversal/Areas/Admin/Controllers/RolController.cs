using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Traversal.Areas.Admin.Models;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Rol")]
    [AllowAnonymous]
    public class RolController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RolController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }
        [HttpGet]
        [Route("CreateRol")]
        public IActionResult CreateRol()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateRol")]
        public async Task<IActionResult> CreateRol(CreateRolViewModel createRolViewModel)
        {
            AppRole role = new AppRole()
            {
                Name = createRolViewModel.RolName
            };
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else { return View(); }

        }
        [Route("DeleteRol/{id}")]
        public async Task<IActionResult> DeleteRol(int id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            await _roleManager.DeleteAsync(value);
            return RedirectToAction("Index");
        }

        [Route("UpdateRol/{id}")]
        [HttpGet]
        public IActionResult UpdateRol(int id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            UpdateRolViewModel updateRolViewModel = new UpdateRolViewModel
            {
                RolId = value.Id,
                RolName = value.Name
            };
            return View(updateRolViewModel);
        }

        [Route("UpdateRol/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateRol(UpdateRolViewModel updateRolViewModel)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == updateRolViewModel.RolId);
            value.Name = updateRolViewModel.RolName;
            await _roleManager.UpdateAsync(value);
            return RedirectToAction("Index");
        }

        [Route("UserList")]
        public IActionResult UserList()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }

        [Route("AssignRol/{id}")]
        public async Task<IActionResult> AssignRol(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            TempData["Userid"] = user.Id;
            var roles = _roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(user);
            List<RoleAssignViewModel> roleAssignViewModels = new List<RoleAssignViewModel>();
            foreach (var item in roles)
            {
                RoleAssignViewModel model = new RoleAssignViewModel();
                model.RoleId = item.Id;
                model.RoleName = item.Name;
                model.RoleExist = userRoles.Contains(item.Name);
                roleAssignViewModels.Add(model);
            }
            return View(roleAssignViewModels);
        }

        [HttpPost]
        [Route("AssignRol/{id}")]
        public async Task<IActionResult> AssignRol(List<RoleAssignViewModel> model)
        {
            var userid = (int)TempData["Userid"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userid);
            foreach (var item in model)
            {
                if (item.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }
            return RedirectToAction("UserList");
        }
    }
}
