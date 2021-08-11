/* Name:    Jovany Romo
 * Date:    8/9/2021
 * Summary: Basic method in order to get the current date and time.
 * 
 * Input:   DateTime.Now
 * Output:  DateTime.Now
 */

using Microsoft.AspNetCore.Mvc;
using System;

namespace TheDeepOTools.Components
{
    public class TimeViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(DateTime.Now);
        }
    }
}
