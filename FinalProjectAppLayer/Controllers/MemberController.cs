using FinalProjectAppLayer.Models;
using FinalProjectAppLayer.Repositories;
using FinalProjectBusinessLayer.Data;
using FinalProjectBusinessLayer.Entitys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectAppLayer.Controllers
{
    //admin 
    public class MemberController : Controller
    {
        private readonly UserManager<Member> _userManager;

        private IMemderRepositorie memderRepositorie;

        public MemberController(IMemderRepositorie memderRepositorie, UserManager<Member> _userManager)
        {
            this.memderRepositorie = memderRepositorie;
            this._userManager = _userManager;
        }

        //Get all members function
        public IActionResult AllMembers()
        {
            ViewBag.allMembers = memderRepositorie.AllMembers();
            
            return View();
        }

        //Add new member function
        public IActionResult NewMember()
        {
            return View();
        }

        //Delete member function
        public IActionResult deleteMember(string id)
        {
            memderRepositorie.deleteMember(id);
            return RedirectToAction("AllMembers");
        }
        public IActionResult EditMember(string id)
        {
            memderRepositorie.EditMember(id);
            return View(memderRepositorie.EditMember(id)); 
        }

        public async Task<IActionResult> EditMemberDone(Member member)
        {
            await memderRepositorie.EditMemberDone(member);
            return RedirectToAction("AllMembers");
        }

        /// <summary>
        /// Function to inserte members depends on their positions.
        /// </summary>
        public async Task <IActionResult> InsertMember(MemberDTO Member, string Position)
        {
            if (Position == "1")
            {
                await memderRepositorie.addProjectManager(Member);
            }

            else if (Position == "2") 
            {
               await memderRepositorie.addTeamLeader(Member);
            }

            else if (Position == "3") 
            {
               await memderRepositorie.addTeamMember(Member);
            }
            
            return RedirectToAction("AllMembers");
        }

    }
}
