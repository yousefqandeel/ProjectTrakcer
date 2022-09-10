using FinalProjectAppLayer.Models;
using FinalProjectBusinessLayer.Data;
using FinalProjectBusinessLayer.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectAppLayer.Repositories
{


    public class TeamLeaderRepositorie : ITeamLeaderRepositorie
    {

        //Dependency Injection 
        private ApplicationDbContext context;
        public TeamLeaderRepositorie(ApplicationDbContext context)
        {
            this.context = context;
        }

        //Get all team leaders function
        public List<TeamLeader> AllTeamLeaders()
        {
            return context.TeamLeaders.ToList();
        }

        //Get all team members function
        public List<TeamMember> AllTeamMembers()
        {
            return context.TeamMembers.ToList();
        }

        //Get all projects function
        public List<ProjectMembers> GetAllProjects(string Id)
        {
            var query= context.ProjectMembers.Include(x => x.Project).Where(x => x.MemberID == Id).ToList();
            return query;
        }

        //Get all sprints function
        public List<Sprint> GetAllSprints()
        {
            return context.Sprints.ToList();
        }

        //create new sprint function
        public void AddSprint(SprintDTO sprintDTO)
        {
            var sprint = new Sprint()
            {
                ProjectID = sprintDTO.ProjectID,
                Name = sprintDTO.Name,
                Description = sprintDTO.Description,
                Start = sprintDTO.StartDate,
                End = sprintDTO.EndDate
                
            };
            context.Sprints.Add(sprint);
            context.SaveChanges();
        }

        //Get all duties function
        public List<Duty> GetAllDuties(int SId)
        {
            return context.Duties.Where(x=>x.SprintID==SId).ToList();
        }

        //Create new duties function
        public void AddDuty(DutyDTO dutyDTO)
        {
            var duty = new Duty()
            {
                SprintID = dutyDTO.SprintID,
                DutyName = dutyDTO.Name,
                TeamMemberID = dutyDTO.TeamMemberID,
                DutyDesctiption = dutyDTO.Description,
                Start = dutyDTO.StartDate,
                End = dutyDTO.EndDate,
                StatusID = 3
                
            };
            context.Duties.Add(duty);
            context.SaveChanges();

        }
        /////////
        public Document ViewPage(int DutyID)
        {
            return context.Documents.SingleOrDefault(x => x.DutyID == DutyID);
        }

        /// <summary>
        /// To get Team member name nested of ID by using SQL queries
        /// </summary>
        public List<TeamMemberForProject> MembersForProject()
        {
            var query = (from u in context.Users
                         join d in context.Duties on u.Id equals d.TeamMemberID
                         join ur in context.UserRoles on u.Id equals ur.UserId
                         select new TeamMemberForProject
                         {
                             ID = u.Id,
                             RoleID = ur.RoleId,
                             UserName = u.FullName,
                             SprintID = d.SprintID
                         }
                       ).ToList();
            return query;
        }

        //Remove sprints function
        public void DeleteSprint(int ID)
        {
            var query = context.Sprints.SingleOrDefault(x => x.SprintID == ID);
            context.Sprints.Remove(query);
            context.SaveChanges();
        }

        //Edit sprints function
        public Sprint EditSprint(int Id)
        {
            var query = context.Sprints.SingleOrDefault(x => x.SprintID == Id);
            return query;
        }

        //Edit sprints function DONE
        public void EditSprintDone(Sprint sprint)
        {
            var query = context.Sprints.SingleOrDefault(x => x.SprintID == sprint.SprintID);
            query.Name = sprint.Name;
            //query.ProjectID = sprint.ProjectID;
            query.Description = sprint.Description;
            query.Start = sprint.Start;
            query.End = sprint.End;
            context.Sprints.Update(query);
            context.SaveChanges();
        }
        //Function to view Document which submitted by team member function
        public Document ViewDocument(int DocId)
        {
            return context.Documents.Include(x=> x.DocumentAttatchments).SingleOrDefault(x => x.DocumentID == DocId);
        }

        //Function to approve documents which submitted by team members
        public void Approve(int DocID)
        {
            var approve = context.Documents.SingleOrDefault(x => x.DocumentID == DocID);
            approve.StatusID = 2;
            context.SaveChanges();
        }

        //Function to reject documents which submitted by team members
        public void Rejected(int DocID,string RejectionNote)
        {
            var approve = context.Documents.SingleOrDefault(x => x.DocumentID == DocID);
            approve.StatusID = 4;
            context.SaveChanges();
        }
    }
}