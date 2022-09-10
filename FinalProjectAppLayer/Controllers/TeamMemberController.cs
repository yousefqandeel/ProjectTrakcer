using FinalProjectAppLayer.Models;
using FinalProjectAppLayer.Repositories;
using FinalProjectBusinessLayer.Data;
using FinalProjectBusinessLayer.Entitys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectAppLayer.Controllers
{
    public class TeamMemberController : Controller
    {
        //Dependency Injection 

        private readonly UserManager<Member> _userManager;
        private ITeamMemberRepositories teamMemberRepositorie;
        public TeamMemberController(ITeamMemberRepositories teamMemberRepositorie, UserManager<Member> _userManager)
        {
            this.teamMemberRepositorie = teamMemberRepositorie;
            this._userManager = _userManager;
        }

        //View all team members function
        public IActionResult AllTeamMembers()
        {
            ViewBag.allMembers = teamMemberRepositorie.AllTeamMembers();
            return View();
        }

        //Add new project manager function
        public IActionResult AddProjectManager(TeamMember teamMember)
        {
            teamMemberRepositorie.AllTeamMembers();
            return View();
        }

        //View all documents function
        public async Task<IActionResult> ViewDocuments(int DutyID)
        {
            ViewBag.DutiesState = teamMemberRepositorie.GetDutyState(DutyID);
            var user = await _userManager.GetUserAsync(User);
            ViewBag.dutyID = DutyID;
            ViewBag.TeamMembers = teamMemberRepositorie.MembersForProject();
            ViewBag.allDocuments = teamMemberRepositorie.GetAllDocuments(DutyID);
            ViewBag.CountApprove = teamMemberRepositorie.DocumentState(DutyID);
            ViewBag.Count = teamMemberRepositorie.AllDocuments(DutyID);
            return View();
        }

        ///////////
        public IActionResult DocumentDone(int DutyId)
        {
            teamMemberRepositorie.DocumentDone(DutyId);
            return RedirectToAction("GetAllDuties");
        }

        //Get all duties function
        public async Task<IActionResult> GetAllDuties(int DutyID)
        {
            var user = await _userManager.GetUserAsync(User);
            ViewBag.dutyID = DutyID;
            ViewBag.TeamMembers = teamMemberRepositorie.MembersForProject();
            ViewBag.allDuties = teamMemberRepositorie.GetAllDuties(user.Id);
            return View();
        }

        //Add new documents to documents list function
        public IActionResult AddDocument(int DutyID)
        {
            ViewBag.dutyID = DutyID;
            
            return View();
        }

        //Create new documents function
        [HttpPost]
        public IActionResult insertDec(DocumentDTO documentDTO,IFormFile File)
        {
           teamMemberRepositorie.AddDocument(documentDTO, File);
            return RedirectToAction("ViewDocuments",new { DutyId=documentDTO.DutyID});
        }

        //Get all documents function
        public IActionResult ViewDocument(int docID)
        {
           
            return View(teamMemberRepositorie.ViewDocument(docID));
        }

        //Function to preview attachment which submitted by team member 
        public async Task<FileResult> AttachmentPreview(int ID)
        {
            var file= await teamMemberRepositorie.PreivewAttachment(ID);
            return File(file.File,file.ContentType);
        }

        //Create new documents function
        public IActionResult InsertDocument(DutyDTO dutyDtO)
        { 
            teamMemberRepositorie.AddDuty(dutyDtO);
            return RedirectToAction("GetAllDuties");
        }

        //Edit documents function
        public IActionResult EditDocument(int Id)
        {
            teamMemberRepositorie.EditDocument(Id);
            return View(teamMemberRepositorie.EditDocument(Id));
        }
        
        public IActionResult EditDocumentDone(Document document, int DutyID)
        {
            teamMemberRepositorie.EditDocumentDone(document);
            return RedirectToAction("ViewDocument", new { DutyID = DutyID});
        }

        //Delete Documents function
        public IActionResult DeleteDocuments(int DocumentID, int DutyID)
        {
            teamMemberRepositorie.DeleteDoc(DocumentID);
            return RedirectToAction("ViewDocuments", new { DutyID= DutyID });
        }
    }
}
