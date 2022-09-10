using FinalProjectAppLayer.Models;
using FinalProjectBusinessLayer.Data;
using FinalProjectBusinessLayer.Entitys;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectAppLayer.Repositories
{

    //Dependency Injection 
    public class TeamMemberRepositories : ITeamMemberRepositories
    {
        private ApplicationDbContext context;
        public TeamMemberRepositories(ApplicationDbContext context)
        {
            this.context = context;
        }

        //Geat all members function
        public List<TeamMember> AllTeamMembers()
        {
            return context.TeamMembers.ToList();
        }

        //Geat all documents function
        public List<Document> GetAllDocuments(int DutyID)
        {
            return context.Documents.Where(x => x.DutyID == DutyID).ToList();
        }

        //Geat all duties function
        public List<Duty> GetAllDuties(string Id)
        {
            return context.Duties.Include(x => x.Documents).Where(x => x.TeamMemberID == Id).ToList();
        }

        //Create new duies function
        public void AddDuty(DutyDTO dutyDTO)
        {
            var duty = new Duty()
            {
                DutyID = dutyDTO.ID,
                DutyName = dutyDTO.Name,
                DutyDesctiption = dutyDTO.Description,
                TeamMemberID = dutyDTO.TeamMemberID,
                SprintID = dutyDTO.SprintID
            };
            context.Duties.Add(duty);
            context.SaveChanges();
        }

        //Create new documents function
        public void AddDocument(DocumentDTO documentDTO, IFormFile File)
        {
            var doc = new Document()
            {
                Name = documentDTO.Name,
                Description = documentDTO.Description,
                DutyID = documentDTO.DutyID,
                StatusID = 3
            };
            context.Documents.Add(doc);
            context.SaveChanges();
            Stream st = File.OpenReadStream();

            //Upload Files
            using (BinaryReader br = new BinaryReader(st))
            {
                DocumentAttatchment f = new DocumentAttatchment();
                f.DocumentID = doc.DocumentID;
                f.FileName = File.FileName;
                f.ContentType = File.ContentType;
                var bytFile = br.ReadBytes((int)st.Length);
                f.File = bytFile;
                context.DocumentAttatchments.Add(f);
                context.SaveChanges();
            }
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

        //Get all documents function
        public List<Document> ViewDocument(int DocumentID)
        {
            return context.Documents.Include(x => x.DocumentAttatchments).Where(x => x.DocumentID == DocumentID).ToList();
        }

        //Set documents states
        public int DocumentState(int DutyID)
        {
            var count = 0;
            var query = context.Documents.Where(x => x.DutyID == DutyID).ToList();
            foreach (var item in query)
            {
                if (item.StatusID == 2)
                {
                    count++;
                }
            }
            return count;
        }

        //Get all documents states
        public int GetDutyState(int DutyID)
        {
            return context.Duties.SingleOrDefault(x => x.DutyID == DutyID).StatusID; 
        }

        //Get all documents
        public int AllDocuments(int DutyId)
        {
          var query=  context.Documents.Where(x => x.DutyID == DutyId).ToList();
            return query.Count;
        }

        //Set documents completely
        public void DocumentDone(int DutyId)
        {
            var query = context.Duties.Where(x => x.DutyID == DutyId).SingleOrDefault();
            query.StatusID = 1;
            context.SaveChanges();
        }

        //Delete Documents
        public void DeleteDoc(int DocumentID)
        {
            var query = context.Documents.SingleOrDefault(x => x.DocumentID == DocumentID);
            context.Remove(query);
            context.SaveChanges();
        }

        //Edit Documents function
        public Document EditDocument(int Id)
        {
            var qurey = context.Documents.SingleOrDefault(x => x.DocumentID == Id);
            return qurey;
        }

        //Edit Documents Done function
        public void EditDocumentDone(Document document)
        {
            var qurey = context.Documents.SingleOrDefault(x => x.DocumentID == document.DocumentID);
            qurey.Name = document.Name;
            qurey.Description = document.Description;
            context.Documents.Update(qurey);
            context.SaveChanges();
        }

        //Shwo all attachments
        public async Task<DocumentAttatchment> PreivewAttachment(int id)
        {
            var query = await context.DocumentAttatchments.SingleOrDefaultAsync(x => x.ID == id);
            return query;
        }
    }
}