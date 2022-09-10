using FinalProjectAppLayer.Models;
using FinalProjectBusinessLayer.Entitys;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectAppLayer.Repositories
{
    /// <summary>
    /// Team Member Interface
    /// </summary>
    public interface ITeamMemberRepositories
    {
        public List<TeamMember> AllTeamMembers();

        public List<TeamMemberForProject> MembersForProject();
        public void AddDuty(DutyDTO dutyDTO);
        public List<Document> GetAllDocuments(int DutyID);
        public List<Duty> GetAllDuties(string Id);
        public void AddDocument(DocumentDTO documentDTO, IFormFile File);
        public List<Document> ViewDocument(int DocumentID);
        public Task<DocumentAttatchment> PreivewAttachment(int id);
        public int DocumentState(int DutyID);
        public int AllDocuments(int DutyId);
        public void DocumentDone(int DutyId);
        public void DeleteDoc(int DocumentID);
        public Document EditDocument(int Id);
        public void EditDocumentDone(Document document);
        public int GetDutyState(int DutyID);
    }
}