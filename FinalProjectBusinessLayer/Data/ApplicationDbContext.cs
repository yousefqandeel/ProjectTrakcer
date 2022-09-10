using FinalProjectBusinessLayer.Entitys;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectBusinessLayer.Data
{
    /// <summary>
    /// In this page I created a DbSets so that I can access it in the program
    /// and created a relations of tables in Database 
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<Member>
    {
        public DbSet<ProjectManager> ProjectManagers { get; set; }
        public DbSet<TeamLeader> TeamLeaders { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectMembers> ProjectMembers { get; set; }
        public DbSet<Duty> Duties { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentAttatchment> DocumentAttatchments { get; set; }
        public DbSet<Status> Statuses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProjectMembers>()
                .HasOne(m => m.Member)
                .WithMany(pm => pm.ProjectMembers).HasForeignKey(f => f.MemberID);

            modelBuilder.Entity<ProjectMembers>()
                .HasOne(p => p.Project)
                .WithMany(pm => pm.ProjectMembers).HasForeignKey(f => f.ProjectID);

            modelBuilder.Entity<ProjectMembers>().HasKey(x => new { x.MemberID, x.ProjectID });

            modelBuilder.Entity<Sprint>()
                .HasOne(x => x.Project)
                .WithMany(s => s.Sprints).HasForeignKey(f => f.ProjectID);


            modelBuilder.Entity<Duty>()
                .HasOne(s => s.Sprint)
                .WithMany(d => d.Duties).HasForeignKey(f => f.DutyID);

            modelBuilder.Entity<Duty>()
                .HasOne(t => t.TeamMember)
                .WithMany(d => d.Duties).HasForeignKey(f => f.TeamMemberID);

            modelBuilder.Entity<Document>()
                .HasOne(d => d.Duty)
                .WithMany(d => d.Documents).HasForeignKey(f => f.DutyID);

            modelBuilder.Entity<DocumentAttatchment>()
                .HasOne(d => d.Document)
                .WithMany(da => da.DocumentAttatchments).HasForeignKey(f => f.DocumentID);

            modelBuilder.Entity<Document>()
                .HasOne(s => s.Status)
                .WithMany(d => d.Documents).HasForeignKey(f => f.StatusID);

            modelBuilder.Entity<Status>()
                .HasMany(d => d.Duties)
                .WithOne(s => s.Statuses).HasForeignKey(f => f.StatusID);
        }
    }
}
