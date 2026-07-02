using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeopleManager.Migrations
{
    /// <inheritdoc />
    public partial class AddChecklistEvaluationRecordedAtAndComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RecordedAt",
                table: "ChecklistItemEvaluations",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            // Backfill existing rows from EvaluatedDate — the closest real data available,
            // better than leaving them at the year-1 column default.
            migrationBuilder.Sql(
                "UPDATE \"ChecklistItemEvaluations\" SET \"RecordedAt\" = \"EvaluatedDate\";");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecordedAt",
                table: "ChecklistItemEvaluations");
        }
    }
}
