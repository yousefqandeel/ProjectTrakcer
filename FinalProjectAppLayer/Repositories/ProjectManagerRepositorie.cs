using FinalProjectAppLayer.Models;
using FinalProjectBusinessLayer.Data;
using FinalProjectBusinessLayer.Entitys;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectAppLayer.Repositories
{
    public class ProjectManagerRepositorie :IProjectManagerRepositorie
    {

        //Dependency Injection 

        private ApplicationDbContext context;
        public ProjectManagerRepositorie(ApplicationDbContext context)
        {
            this.context = context;
        }

        //Get all project managers function
        public List<ProjectManager> AllProjectManagers()
        {
            return context.ProjectManagers.ToList();
        }

        //Get all teamleaders function
        public List<TeamLeader> AllTeamLeaders()
        {
            return context.TeamLeaders.ToList();
        }

        //Get all projects function
        public List<ProjectMembers> GetAllProjects(string Id)
        {
            return context.ProjectMembers.Include(x => x.Project).Where(x => x.MemberID == Id).ToList();
        }

        //Create new projects function
        public void NewProject(ProjectDTO projectDTO,string Id)
        {
            var project = new Project()
            {
                ProjectName = projectDTO.Name,
                ProjectDescription = projectDTO.Description,
                Deadline = projectDTO.Deadline,                
            };
            context.Projects.Add(project);
            context.SaveChanges();
            var UserManger = new ProjectMembers()
            {
                MemberID = Id,
                ProjectID = project.ProjectID
            };
            context.ProjectMembers.Add(UserManger);
            context.SaveChanges();
            var TeamLeader = new ProjectMembers()
            {
                MemberID = projectDTO.TeamLeaderID,
                ProjectID = project.ProjectID
            };
            context.ProjectMembers.Add(TeamLeader);
            context.SaveChanges();
        }

        //Delete project function
        public void DeleteProject(int ID)
        {
            var deletedProj = context.Projects.SingleOrDefault(x=> x.ProjectID == ID);
            context.Projects.Remove(deletedProj);
            context.SaveChanges();
        }
        
        /// <summary>
        /// To get Team leader name nested of ID by using SQL queries
        /// </summary>
        public List<TeamLeaderForProjectDTO> LeaderForProject()
        {
            var query = (from u in context.Users
                         join pm in context.ProjectMembers on u.Id equals pm.MemberID
                         join p in context.Projects on pm.ProjectID equals p.ProjectID
                         join ur in context.UserRoles on u.Id equals ur.UserId
                         select new TeamLeaderForProjectDTO
                         {
                             ID = u.Id,
                             RoleID = ur.RoleId,
                             UserName = u.FullName,
                             ProjectID = p.ProjectID
                         }
                       ).ToList();
            return query;
        }

        //Edit Project function
        public Project EditProject(int Id)
        {
            var query = context.Projects.SingleOrDefault(x => x.ProjectID == Id);
            return query;
        }

        public void EditProjectDone(Project project)
        {
            var query = context.Projects.SingleOrDefault(x => x.ProjectID == project.ProjectID);
            query.ProjectName = project.ProjectName;
            query.ProjectDescription = project.ProjectDescription;
            query.Deadline = project.Deadline;
            context.Projects.Update(query);
            context.SaveChanges();
        }
    }
}