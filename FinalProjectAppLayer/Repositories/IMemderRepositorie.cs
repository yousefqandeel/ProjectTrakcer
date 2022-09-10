using FinalProjectAppLayer.Models;
using FinalProjectBusinessLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectAppLayer.Repositories
{
    public interface IMemderRepositorie
    {
        /// <summary>
        /// Member Interface
        /// </summary>
        /// 
        public List<Member> AllMembers();
        public Member EditMember(string Id);
        public Task addProjectManager(MemberDTO ProjectManagerDto);
        public List<TeamLeader> AllTeamLeader();
        public Task addTeamLeader(MemberDTO teamLeader);
        public Task addTeamMember(MemberDTO teamMemberDTO);
        public void deleteMember(string Id);
        Task EditMemberDone(Member member);
    }
}
