using FinalProjectAppLayer.Models;
using FinalProjectBusinessLayer.Data;
using FinalProjectBusinessLayer.Entitys;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectAppLayer.Repositories
{
    public class MemderRepositorie : IMemderRepositorie
    {
        // Dependency Injection 

        private ApplicationDbContext context;
        private readonly UserManager<Member> _userManager;
        private readonly IPasswordHasher<Member> phash;

        public MemderRepositorie(ApplicationDbContext context, UserManager<Member> _userManager,
            IPasswordHasher<Member> Phash)
        {
            this.context = context;
            this._userManager = _userManager;
            phash = Phash;
        }

        //Get all members function
        public List<Member> AllMembers()
        {
            return context.Users.ToList();
        }
        //Get all teamleaders function
        public List<TeamLeader> AllTeamLeader()
        {
            return context.TeamLeaders.ToList();
        }

        //Create project managers function
        public async Task addProjectManager(MemberDTO ProjectManagerDto)
        {
            var ProjectManager = new ProjectManager()
            {
                FullName = ProjectManagerDto.FullName,
                UserName = ProjectManagerDto.Email,
                Email = ProjectManagerDto.Email,
                EmailConfirmed = true
            };
            await _userManager.CreateAsync(ProjectManager, ProjectManagerDto.Password);
            var user_role = new IdentityUserRole<string>()
            {
                UserId = ProjectManager.Id,
                RoleId = "2"
            };
            context.UserRoles.Add(user_role);
            context.SaveChanges();
        }

        //Create team leaders function
        public async Task addTeamLeader(MemberDTO TeamLeaderDto)
        {
            var TeamLeader = new TeamLeader()
            {
                FullName = TeamLeaderDto.FullName,
                UserName = TeamLeaderDto.Email,
                Email = TeamLeaderDto.Email,
                EmailConfirmed = true
            };
            await _userManager.CreateAsync(TeamLeader, TeamLeaderDto.Password);
            var user_role = new IdentityUserRole<string>()
            {
                UserId = TeamLeader.Id,
                RoleId = "3"
            };
            context.UserRoles.Add(user_role);
            context.SaveChanges();
        }

        //Create team members function
        public async Task addTeamMember(MemberDTO teamMemberDTO)
        {
            var TeamMember = new TeamMember()
            {
                FullName = teamMemberDTO.FullName,
                UserName = teamMemberDTO.Email,
                Email = teamMemberDTO.Email,
                EmailConfirmed = true
            };
            await _userManager.CreateAsync(TeamMember, teamMemberDTO.Password);
            var user_role = new IdentityUserRole<string>()
            {
                UserId = TeamMember.Id,
                RoleId = "4"
            };
            context.UserRoles.Add(user_role);
            context.SaveChanges();
        }

        //Remove member function
        public void deleteMember(string Id)
        {
            var DeletedUser=context.Users.SingleOrDefault(x => x.Id == Id);

            context.Users.Remove(DeletedUser);
            context.SaveChanges();
        }
        
        public Member EditMember(string Id)
        {
            var EditUser=context.Users.SingleOrDefault(x => x.Id == Id);
            return EditUser;
        }

        public async Task EditMemberDone(Member member)
        {
            var query = context.Users.SingleOrDefault(x => x.Id == member.Id);
            query.FullName = member.FullName;
            query.Email = member.Email;
            var passwordAfterHash = phash.HashPassword(query, member.PasswordHash);
            query.PasswordHash = passwordAfterHash;
            await _userManager.UpdateAsync(query);
        }

    }
}
