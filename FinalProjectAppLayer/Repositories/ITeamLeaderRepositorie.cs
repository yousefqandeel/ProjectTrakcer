using FinalProjectAppLayer.Models;
using FinalProjectBusinessLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectAppLayer.Repositories
{
    public interface ITeamLeaderRepositorie
    {
        /// <summary>
        /// TeamLeader Interface
        /// </summary>
        public List<TeamLeader> AllTeamLeaders();
        public List<ProjectMembers> GetAllProjects(string Id);
        public List<TeamMember> AllTeamMembers();
        public List<Duty> GetAllDuties(int SId);
        public void AddDuty(DutyDTO dutyDTO);
        public List<Sprint> GetAllSprints();
        public void AddSprint(SprintDTO sprintDTO);
        public Document ViewPage(int DutyID);
        public void DeleteSprint(int ID);
        public Sprint EditSprint(int Id);
        public void EditSprintDone(Sprint sprint);
        public List<TeamMemberForProject> MembersForProject();
        Document ViewDocument(int DocId);
        void Approve(int DocID);
        void Rejected(int DocID, string RejectionNote);
        //public void AddStatus(int ID);
    }
}