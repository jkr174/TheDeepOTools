/* Name:    Jovany Romo
 * Date:    7/26/2021
 * Summary: Controller for managing roles in the web application.
 * 
 * Inputs:  When an Admin or Manager loads into the RoleManager section of the web application.
 * Outputs: Assuming the user is authorized, then they are able to add new roles to the web application.
 */

using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TheDeepOTools.Controllers
{
    public class RoleManagerController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleManagerController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        /// <summary>
        /// A view of all of the roles in the web application.
        /// </summary>
        /// <returns>
        /// If the user is authorized, then they can view all of the roles in the web application.
        /// </returns>
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }

        /// <summary>
        /// Method for an authorized user to Add roles to the web application.
        /// </summary>
        /// <param name="roleName">Name of the user roles</param>
        /// <returns>
        /// Once a role is created, it is saved to the web application.
        /// </returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> AddRole(string roleName)
        {
            if (roleName != null)
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName.Trim()));
            }
            return RedirectToAction("Index");
        }
    }
}