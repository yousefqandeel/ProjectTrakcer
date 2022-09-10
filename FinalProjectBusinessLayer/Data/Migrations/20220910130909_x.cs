using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectBusinessLayer.Data.Migrations
{
    public partial class x : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "Discriminator",
            //    table: "AspNetUsers",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<string>(
            //    name: "FullName",
            //    table: "AspNetUsers",
            //    nullable: true);

            //migrationBuilder.CreateTable(
            //    name: "Projects",
            //    columns: table => new
            //    {
            //        ProjectID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ProjectName = table.Column<string>(nullable: true),
            //        ProjectDescription = table.Column<string>(nullable: true),
            //        Deadline = table.Column<DateTime>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Projects", x => x.ProjectID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Statuses",
            //    columns: table => new
            //    {
            //        StatusID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        StatusName = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Statuses", x => x.StatusID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ProjectMembers",
            //    columns: table => new
            //    {
            //        MemberID = table.Column<string>(nullable: false),
            //        ProjectID = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ProjectMembers", x => new { x.MemberID, x.ProjectID });
            //        table.ForeignKey(
            //            name: "FK_ProjectMembers_AspNetUsers_MemberID",
            //            column: x => x.MemberID,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ProjectMembers_Projects_ProjectID",
            //            column: x => x.ProjectID,
            //            principalTable: "Projects",
            //            principalColumn: "ProjectID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Sprints",
            //    columns: table => new
            //    {
            //        SprintID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(nullable: true),
            //        Description = table.Column<string>(nullable: true),
            //        Start = table.Column<DateTime>(nullable: false),
            //        End = table.Column<DateTime>(nullable: false),
            //        ProjectID = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Sprints", x => x.SprintID);
            //        table.ForeignKey(
            //            name: "FK_Sprints_Projects_ProjectID",
            //            column: x => x.ProjectID,
            //            principalTable: "Projects",
            //            principalColumn: "ProjectID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Duties",
            //    columns: table => new
            //    {
            //        DutyID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        DutyName = table.Column<string>(nullable: true),
            //        DutyDesctiption = table.Column<string>(nullable: true),
            //        Status = table.Column<string>(nullable: true),
            //        Start = table.Column<DateTime>(nullable: false),
            //        End = table.Column<DateTime>(nullable: false),
            //        SprintID = table.Column<int>(nullable: false),
            //        TeamMemberID = table.Column<string>(nullable: true),
            //        StatusID = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Duties", x => x.DutyID);
            //        table.ForeignKey(
            //            name: "FK_Duties_Sprints_DutyID",
            //            column: x => x.DutyID,
            //            principalTable: "Sprints",
            //            principalColumn: "SprintID",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Duties_Statuses_StatusID",
            //            column: x => x.StatusID,
            //            principalTable: "Statuses",
            //            principalColumn: "StatusID",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Duties_AspNetUsers_TeamMemberID",
            //            column: x => x.TeamMemberID,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Documents",
            //    columns: table => new
            //    {
            //        DocumentID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(nullable: true),
            //        Description = table.Column<string>(nullable: true),
            //        DutyID = table.Column<int>(nullable: false),
            //        StatusID = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Documents", x => x.DocumentID);
            //        table.ForeignKey(
            //            name: "FK_Documents_Duties_DutyID",
            //            column: x => x.DutyID,
            //            principalTable: "Duties",
            //            principalColumn: "DutyID",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Documents_Statuses_StatusID",
            //            column: x => x.StatusID,
            //            principalTable: "Statuses",
            //            principalColumn: "StatusID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "DocumentAttatchments",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FileName = table.Column<string>(nullable: true),
            //        ContentType = table.Column<string>(nullable: true),
            //        File = table.Column<byte[]>(nullable: true),
            //        DocumentID = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_DocumentAttatchments", x => x.ID);
            //        table.ForeignKey(
            //            name: "FK_DocumentAttatchments_Documents_DocumentID",
            //            column: x => x.DocumentID,
            //            principalTable: "Documents",
            //            principalColumn: "DocumentID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            migrationBuilder.CreateTable(
                name: "Histories",
                columns: table => new
                {
                    HistoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RejectionNote = table.Column<string>(nullable: true),
                    StatusID = table.Column<int>(nullable: false),
                    DocumentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Histories", x => x.HistoryID);
                    table.ForeignKey(
                        name: "FK_Histories_Documents_DocumentID",
                        column: x => x.DocumentID,
                        principalTable: "Documents",
                        principalColumn: "DocumentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Histories_Statuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Statuses",
                        principalColumn: "StatusID",
                        onDelete: ReferentialAction.Restrict);
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_DocumentAttatchments_DocumentID",
            //    table: "DocumentAttatchments",
            //    column: "DocumentID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Documents_DutyID",
            //    table: "Documents",
            //    column: "DutyID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Documents_StatusID",
            //    table: "Documents",
            //    column: "StatusID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Duties_StatusID",
            //    table: "Duties",
            //    column: "StatusID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Duties_TeamMemberID",
            //    table: "Duties",
            //    column: "TeamMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_DocumentID",
                table: "Histories",
                column: "DocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_StatusID",
                table: "Histories",
                column: "StatusID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProjectMembers_ProjectID",
            //    table: "ProjectMembers",
            //    column: "ProjectID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Sprints_ProjectID",
            //    table: "Sprints",
            //    column: "ProjectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "DocumentAttatchments");

            migrationBuilder.DropTable(
                name: "Histories");

            //migrationBuilder.DropTable(
            //    name: "ProjectMembers");

            //migrationBuilder.DropTable(
            //    name: "Documents");

            //migrationBuilder.DropTable(
            //    name: "Duties");

            //migrationBuilder.DropTable(
            //    name: "Sprints");

            //migrationBuilder.DropTable(
            //    name: "Statuses");

            //migrationBuilder.DropTable(
            //    name: "Projects");

            //migrationBuilder.DropColumn(
            //    name: "Discriminator",
            //    table: "AspNetUsers");

            //migrationBuilder.DropColumn(
            //    name: "FullName",
            //    table: "AspNetUsers");
        }
    }
}
