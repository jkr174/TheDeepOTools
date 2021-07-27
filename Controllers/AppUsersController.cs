using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TheDeepOWebApp.Models;

namespace TheDeepOWebApp.Controllers
{
    public class AppUsersController : Controller
    {
        public ViewResult Index() =>
            View(new Dictionary<string, object>
            { ["Placeholder"] = "Placeholder" });
    }
}
