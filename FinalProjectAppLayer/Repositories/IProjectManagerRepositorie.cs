using FinalProjectAppLayer.Models;
using FinalProjectBusinessLayer.Entitys;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectAppLayer.Repositories
{
    /// <summary>
    /// ProjectManager Interface
    /// </summary>
    public interface IProjectManagerRepositorie
    {
        public List<ProjectManager> AllProjectManagers();
        public List<TeamLeader> AllTeamLeaders();
        public List<ProjectMembers> GetAllProjects(string Id);
        public void NewProject(ProjectDTO projectDTO,string Id);
        public void DeleteProject(int ID);
        public List<TeamLeaderForProjectDTO> LeaderForProject();
        public Project EditProject(int Id);
        public void EditProjectDone(Project project);
    }
}
