using FinalProjectAppLayer.Models;
using FinalProjectAppLayer.Repositories;
using FinalProjectBusinessLayer.Data;
using FinalProjectBusinessLayer.Entitys;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectAppLayer.Controllers
{
    public class TeamLeaderController : Controller
    {
        // Dependency Injection 

        private readonly UserManager<Member> _userManager;

        private ITeamLeaderRepositorie teamLeaderRepositorie;
        private ITeamMemberRepositories teamMemberRepositories;
        public TeamLeaderController(ITeamLeaderRepositorie teamLeaderRepositorie, ITeamMemberRepositories teamMemberRepositories, UserManager<Member> _userManager)
        {
            this.teamLeaderRepositorie = teamLeaderRepositorie;
            this.teamMemberRepositories = teamMemberRepositories;
            this._userManager = _userManager;
        }
        public IActionResult AllTeamLeaders()
        {
            ViewBag.allMembers = teamLeaderRepositorie.AllTeamLeaders();
            return View();
        }

        //View All Projects function
        public async Task <IActionResult> ViewProjects()
        {
            var user= await _userManager.GetUserAsync(User);
            ViewBag.TeamMembers = teamLeaderRepositorie.AllTeamMembers();
            ViewBag.allProjects = teamLeaderRepositorie.GetAllProjects(user.Id);
            return View();
        }

        //View All Sprints function
        public IActionResult ViewSprints(int projectID)
        {
            ViewBag.projectID = projectID;
            ViewBag.allSprints = teamLeaderRepositorie.GetAllSprints();
            return View();
        }    //View All Sprints function
        public IActionResult DefaultLeaderPage()
        {
            
            return View();
        }

        // Add new sprint function
        public IActionResult AddSprint(int projectID)
        {
            ViewBag.projectID = projectID;
            return View();
        }

        //Add new Sprint to sprints list function
        public IActionResult InsertSprint(SprintDTO sprint)
        {
            teamLeaderRepositorie.AddSprint(sprint);
            return RedirectToAction("ViewSprints",new { projectID = sprint.ProjectID});
        }

        //View all duties function
        public IActionResult ViewDuties(int SprintID)
        {
            ViewBag.sprintID = SprintID;
            ViewBag.teamMembers = teamLeaderRepositorie.MembersForProject();
            ViewBag.allDuties = teamLeaderRepositorie.GetAllDuties(SprintID);
            return View();
        }

        //Add new Duty function
        public IActionResult AddDuty(int SprintID)
        {
            ViewBag.AllTeamLeader = teamLeaderRepositorie.AllTeamMembers();
            ViewBag.sprintID = SprintID;
            return View();
        }

        //Add Duty to duties list function
        public IActionResult InsertDuty(DutyDTO duty)
        {
            teamLeaderRepositorie.AddDuty(duty);
            return RedirectToAction("ViewDuties", new { SprintID = duty.SprintID});
        }

        //View Document which submitted by team member function
        public IActionResult ViewDocuments(int DutyID,int DocID)
        {
            return View(teamLeaderRepositorie.ViewDocument(DocID));
        }

        //View All Documents function
        public IActionResult AllDocuments(int DutyID)
        {
            ViewBag.DutiesState = teamMemberRepositories.GetDutyState(DutyID);
            ViewBag.dutyID = DutyID;
            ViewBag.TeamMembers = teamMemberRepositories.MembersForProject();
            ViewBag.allDocuments = teamMemberRepositories.GetAllDocuments(DutyID);
            ViewBag.CountApprove = teamMemberRepositories.DocumentState(DutyID);
            ViewBag.Count = teamMemberRepositories.AllDocuments(DutyID);
            return View();
        }

        //////////////////////
        public IActionResult ViewPage(int DutyID)
        {
            ViewBag.dutyID = DutyID;
            ViewBag.DocumentList = teamLeaderRepositorie.ViewPage(DutyID);
            return View();
        }

        //Delete sprint function
        public IActionResult DeleteSprint(int ID,int projectId)
        {
            teamLeaderRepositorie.DeleteSprint(ID);
            return RedirectToAction("ViewSprints", new { projectID = projectId });
        }

        //Function to change status from Pending to Approve
        [HttpPost]
        public JsonResult Approve(int DocumentID)
        {
            teamLeaderRepositorie.Approve(DocumentID);
            return Json("");
        }

        //Function to change status from Pending to Rejected
        [HttpPost]
        public JsonResult Rejected(int DocumentID,string RejectionNote)
        {
            teamLeaderRepositorie.Rejected(DocumentID, RejectionNote);
            return Json("");
        }

        public IActionResult EditSprint(int Id)
        {
            teamLeaderRepositorie.EditSprint(Id);
            return View(teamLeaderRepositorie.EditSprint(Id));
        }
        public IActionResult EditSprintDone(Sprint sprint, int ProjectID)
        {
            teamLeaderRepositorie.EditSprintDone(sprint);
            return RedirectToAction("ViewSprints", new {ProjectID = ProjectID});
        }
    }
}
