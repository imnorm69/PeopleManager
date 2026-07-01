using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeopleManager.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChecklistQuestions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    ValueType = table.Column<int>(type: "INTEGER", nullable: false),
                    SortOrder = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChecklistQuestions", x => x.QuestionId);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTeams",
                columns: table => new
                {
                    ProjectTeamId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTeams", x => x.ProjectTeamId);
                });

            migrationBuilder.CreateTable(
                name: "GlowsGrows",
                columns: table => new
                {
                    GlowGrowId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Note = table.Column<string>(type: "TEXT", nullable: false),
                    Source = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CommunicatedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlowsGrows", x => x.GlowGrowId);
                    table.ForeignKey(
                        name: "FK_GlowsGrows_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    MeetingId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false),
                    MeetingDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.MeetingId);
                    table.ForeignKey(
                        name: "FK_Meetings_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonEmploymentPeriods",
                columns: table => new
                {
                    PeriodId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false),
                    HireDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SeparationDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    SeparationReason = table.Column<int>(type: "INTEGER", nullable: true),
                    SeparationNotes = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonEmploymentPeriods", x => x.PeriodId);
                    table.ForeignKey(
                        name: "FK_PersonEmploymentPeriods_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonJobTitles",
                columns: table => new
                {
                    PersonJobTitleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonJobTitles", x => x.PersonJobTitleId);
                    table.ForeignKey(
                        name: "FK_PersonJobTitles_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonQuestionAssignments",
                columns: table => new
                {
                    AssignmentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false),
                    QuestionId = table.Column<int>(type: "INTEGER", nullable: false),
                    Frequency = table.Column<int>(type: "INTEGER", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonQuestionAssignments", x => x.AssignmentId);
                    table.ForeignKey(
                        name: "FK_PersonQuestionAssignments_ChecklistQuestions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "ChecklistQuestions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonQuestionAssignments_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonProjectAssignments",
                columns: table => new
                {
                    AssignmentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProjectTeamId = table.Column<int>(type: "INTEGER", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RemovedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonProjectAssignments", x => x.AssignmentId);
                    table.ForeignKey(
                        name: "FK_PersonProjectAssignments_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonProjectAssignments_ProjectTeams_ProjectTeamId",
                        column: x => x.ProjectTeamId,
                        principalTable: "ProjectTeams",
                        principalColumn: "ProjectTeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActionItems",
                columns: table => new
                {
                    ActionItemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedInMeetingId = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    AssignedTo = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DueDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsComplete = table.Column<bool>(type: "INTEGER", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CompletionNotes = table.Column<string>(type: "TEXT", nullable: true),
                    CompletedInMeetingId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionItems", x => x.ActionItemId);
                    table.ForeignKey(
                        name: "FK_ActionItems_Meetings_CompletedInMeetingId",
                        column: x => x.CompletedInMeetingId,
                        principalTable: "Meetings",
                        principalColumn: "MeetingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActionItems_Meetings_CreatedInMeetingId",
                        column: x => x.CreatedInMeetingId,
                        principalTable: "Meetings",
                        principalColumn: "MeetingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActionItems_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChecklistItemEvaluations",
                columns: table => new
                {
                    EvaluationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false),
                    QuestionId = table.Column<int>(type: "INTEGER", nullable: false),
                    MeetingId = table.Column<int>(type: "INTEGER", nullable: true),
                    EvaluatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChecklistItemEvaluations", x => x.EvaluationId);
                    table.ForeignKey(
                        name: "FK_ChecklistItemEvaluations_ChecklistQuestions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "ChecklistQuestions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChecklistItemEvaluations_Meetings_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meetings",
                        principalColumn: "MeetingId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ChecklistItemEvaluations_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeetingNotes",
                columns: table => new
                {
                    MeetingNoteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MeetingId = table.Column<int>(type: "INTEGER", nullable: false),
                    Category = table.Column<int>(type: "INTEGER", nullable: false),
                    NoteText = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingNotes", x => x.MeetingNoteId);
                    table.ForeignKey(
                        name: "FK_MeetingNotes_Meetings_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meetings",
                        principalColumn: "MeetingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionItems_CompletedInMeetingId",
                table: "ActionItems",
                column: "CompletedInMeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionItems_CreatedInMeetingId",
                table: "ActionItems",
                column: "CreatedInMeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionItems_PersonId_IsComplete",
                table: "ActionItems",
                columns: new[] { "PersonId", "IsComplete" });

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistItemEvaluations_MeetingId",
                table: "ChecklistItemEvaluations",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistItemEvaluations_PersonId_QuestionId_EvaluatedDate",
                table: "ChecklistItemEvaluations",
                columns: new[] { "PersonId", "QuestionId", "EvaluatedDate" });

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistItemEvaluations_QuestionId",
                table: "ChecklistItemEvaluations",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_GlowsGrows_PersonId",
                table: "GlowsGrows",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingNotes_MeetingId",
                table: "MeetingNotes",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_PersonId",
                table: "Meetings",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonEmploymentPeriods_PersonId_SeparationDate",
                table: "PersonEmploymentPeriods",
                columns: new[] { "PersonId", "SeparationDate" });

            migrationBuilder.CreateIndex(
                name: "IX_PersonJobTitles_PersonId_EffectiveDate",
                table: "PersonJobTitles",
                columns: new[] { "PersonId", "EffectiveDate" });

            migrationBuilder.CreateIndex(
                name: "IX_PersonProjectAssignments_PersonId_RemovedDate",
                table: "PersonProjectAssignments",
                columns: new[] { "PersonId", "RemovedDate" });

            migrationBuilder.CreateIndex(
                name: "IX_PersonProjectAssignments_ProjectTeamId",
                table: "PersonProjectAssignments",
                column: "ProjectTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonQuestionAssignments_PersonId_QuestionId",
                table: "PersonQuestionAssignments",
                columns: new[] { "PersonId", "QuestionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonQuestionAssignments_QuestionId",
                table: "PersonQuestionAssignments",
                column: "QuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionItems");

            migrationBuilder.DropTable(
                name: "ChecklistItemEvaluations");

            migrationBuilder.DropTable(
                name: "GlowsGrows");

            migrationBuilder.DropTable(
                name: "MeetingNotes");

            migrationBuilder.DropTable(
                name: "PersonEmploymentPeriods");

            migrationBuilder.DropTable(
                name: "PersonJobTitles");

            migrationBuilder.DropTable(
                name: "PersonProjectAssignments");

            migrationBuilder.DropTable(
                name: "PersonQuestionAssignments");

            migrationBuilder.DropTable(
                name: "Meetings");

            migrationBuilder.DropTable(
                name: "ProjectTeams");

            migrationBuilder.DropTable(
                name: "ChecklistQuestions");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
