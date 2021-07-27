using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheDeepOWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using TheDeepOWebApp.Data;

namespace TheDeepOWebApp.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<AppUser> userManager;

        public AdminController(UserManager<AppUser> usrMgr)
        {
            userManager = usrMgr;
        }
        public ViewResult Index() => View(userManager.Users);
    }
}
