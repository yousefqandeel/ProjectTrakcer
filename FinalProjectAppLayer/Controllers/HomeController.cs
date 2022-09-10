using FinalProjectAppLayer.Models;
using FinalProjectBusinessLayer.Entitys;
using ICSharpCode.Decompiler.CSharp.Syntax;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectAppLayer.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private  UserManager<Member> usermanger;

        public HomeController(UserManager<Member> usermanger, ILogger<HomeController> logger)
        {
            this.usermanger = usermanger;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public async Task <IActionResult> Login()
        {
            var user = await usermanger.GetUserAsync(User);
            //Console.WriteLine(Roles.GetRolesForUser());
            if (user == null)
            {
                //return LocalRedirect("/Identity/Account/Register");
                return LocalRedirect("/Identity/Account/Login");

            }
            else if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index");
            }
            else if (User.IsInRole("TeamLeader"))
            {
                return RedirectToAction("ViewProjects", "TeamLeader");
            }
            else if (User.IsInRole("ProjectManager"))
            {
                return RedirectToAction("AllProjects", "ProjectManager");
            }
            else if (User.IsInRole("TeamLeader"))
            {
                return RedirectToAction("ViewSprints", "TeamLeader");
            }
            else if (User.IsInRole("TeamMember"))
            {
                return RedirectToAction("GetAllDuties", "TeamMember");
            }
            else
            {
                return RedirectToAction("DefaultLeaderPage", "TeamLeader");
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
