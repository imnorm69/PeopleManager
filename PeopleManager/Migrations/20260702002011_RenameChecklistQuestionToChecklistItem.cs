using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeopleManager.Migrations
{
    /// <inheritdoc />
    public partial class RenameChecklistQuestionToChecklistItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChecklistItemEvaluations_ChecklistQuestions_QuestionId",
                table: "ChecklistItemEvaluations");

            migrationBuilder.DropTable(
                name: "PersonQuestionAssignments");

            migrationBuilder.DropTable(
                name: "ChecklistQuestions");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "ChecklistItemEvaluations",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_ChecklistItemEvaluations_QuestionId",
                table: "ChecklistItemEvaluations",
                newName: "IX_ChecklistItemEvaluations_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_ChecklistItemEvaluations_PersonId_QuestionId_EvaluatedDate",
                table: "ChecklistItemEvaluations",
                newName: "IX_ChecklistItemEvaluations_PersonId_ItemId_EvaluatedDate");

            migrationBuilder.CreateTable(
                name: "ChecklistItems",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    ValueType = table.Column<int>(type: "INTEGER", nullable: false),
                    SortOrder = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChecklistItems", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "PersonItemAssignments",
                columns: table => new
                {
                    AssignmentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    Frequency = table.Column<int>(type: "INTEGER", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonItemAssignments", x => x.AssignmentId);
                    table.ForeignKey(
                        name: "FK_PersonItemAssignments_ChecklistItems_ItemId",
                        column: x => x.ItemId,
                        principalTable: "ChecklistItems",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonItemAssignments_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonItemAssignments_ItemId",
                table: "PersonItemAssignments",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonItemAssignments_PersonId_ItemId",
                table: "PersonItemAssignments",
                columns: new[] { "PersonId", "ItemId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ChecklistItemEvaluations_ChecklistItems_ItemId",
                table: "ChecklistItemEvaluations",
                column: "ItemId",
                principalTable: "ChecklistItems",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChecklistItemEvaluations_ChecklistItems_ItemId",
                table: "ChecklistItemEvaluations");

            migrationBuilder.DropTable(
                name: "PersonItemAssignments");

            migrationBuilder.DropTable(
                name: "ChecklistItems");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "ChecklistItemEvaluations",
                newName: "QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_ChecklistItemEvaluations_PersonId_ItemId_EvaluatedDate",
                table: "ChecklistItemEvaluations",
                newName: "IX_ChecklistItemEvaluations_PersonId_QuestionId_EvaluatedDate");

            migrationBuilder.RenameIndex(
                name: "IX_ChecklistItemEvaluations_ItemId",
                table: "ChecklistItemEvaluations",
                newName: "IX_ChecklistItemEvaluations_QuestionId");

            migrationBuilder.CreateTable(
                name: "ChecklistQuestions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    SortOrder = table.Column<int>(type: "INTEGER", nullable: false),
                    ValueType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChecklistQuestions", x => x.QuestionId);
                });

            migrationBuilder.CreateTable(
                name: "PersonQuestionAssignments",
                columns: table => new
                {
                    AssignmentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false),
                    QuestionId = table.Column<int>(type: "INTEGER", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Frequency = table.Column<int>(type: "INTEGER", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_PersonQuestionAssignments_PersonId_QuestionId",
                table: "PersonQuestionAssignments",
                columns: new[] { "PersonId", "QuestionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonQuestionAssignments_QuestionId",
                table: "PersonQuestionAssignments",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChecklistItemEvaluations_ChecklistQuestions_QuestionId",
                table: "ChecklistItemEvaluations",
                column: "QuestionId",
                principalTable: "ChecklistQuestions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
