using PL.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using PL;
using System.Web;
using System.Web.Mvc;

namespace Pl.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RollController : Controller
    {
        private ApplicationRoleManager _roleManager;
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }

            private set
            {
                _roleManager = value;
            }
        }
        [HttpGet]
        public ActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddRole(RegisterRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole { Name = model.RoleName };
                IdentityResult result = RoleManager.Create(role);
                if (result.Succeeded)
                {
                    string RoleId = role.Id;
                    return RedirectToAction("Index", "Home", new { Id = RoleId });
                }

                foreach (string error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
            }

            return View(model);
        }
        [HttpPost]
        public ActionResult AssignUserToRole(string userId, string roleName)
        {
            ApplicationUserManager UserManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            IdentityResult result = UserManager.AddToRole(userId, roleName);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }

            return View();
        }
        [HttpGet]
        public ActionResult AssignUserToRole()
        {
            return View();
        }
    }
}