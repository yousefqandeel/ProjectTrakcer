using FinalProjectAppLayer.Models;
using FinalProjectAppLayer.Repositories;
using FinalProjectBusinessLayer.Entitys;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FinalProjectAppLayer.Controllers
{
    public class ProjectManagerController : Controller
    {
        // Dependency Injection 

        private readonly UserManager<Member> _userManager;
        private readonly IProjectManagerRepositorie projectManagerRepositorie;
        public ProjectManagerController(IProjectManagerRepositorie projectManagerRepositorie, UserManager<Member> _userManager)
        {
            this.projectManagerRepositorie = projectManagerRepositorie;
            this._userManager = _userManager;
            
        }

        //Get all project managers function
        public IActionResult AllProjectManagers()
        {
            ViewBag.allMembers = projectManagerRepositorie.AllProjectManagers();
            return View();
        }

        //Show all projects function
        public async Task <IActionResult> AllProjects()
        {
            var user = await _userManager.GetUserAsync(User);
            ViewBag.TleaderDto = projectManagerRepositorie.LeaderForProject();
            ViewBag.allProjects = projectManagerRepositorie.GetAllProjects(user.Id);
            return View();
        }

        //Function to create new projects 
        public IActionResult NewProject()
        {
            ViewBag.AllTeamLeader = projectManagerRepositorie.AllTeamLeaders();
            return View();
        }

        //Add project to projects list function
        public async Task <IActionResult> InsertProject(ProjectDTO project)
        {
            var user = await _userManager.GetUserAsync(User);
            projectManagerRepositorie.NewProject(project,user.Id);
            return RedirectToAction("AllProjects");
        }
        public IActionResult DeleteProject(int ID)
        {
            projectManagerRepositorie.DeleteProject(ID);
            return RedirectToAction("AllProjects");
        }
        public IActionResult EditProject(int Id)
        {
            projectManagerRepositorie.EditProject(Id);
            return View(projectManagerRepositorie.EditProject(Id));
        }
        public IActionResult EditProjectDone(Project project)
        {
            projectManagerRepositorie.EditProjectDone(project);
            return RedirectToAction("AllProjects");
        }
    }
}