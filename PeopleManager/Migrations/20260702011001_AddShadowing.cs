using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeopleManager.Migrations
{
    /// <inheritdoc />
    public partial class AddShadowing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ExcludedFromShadowing",
                table: "People",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ShadowSessions",
                columns: table => new
                {
                    ShadowSessionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ShadowerId = table.Column<int>(type: "INTEGER", nullable: false),
                    ObservedPersonId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeamObserved = table.Column<string>(type: "TEXT", nullable: false),
                    EventType = table.Column<int>(type: "INTEGER", nullable: false),
                    Points = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShadowSessions", x => x.ShadowSessionId);
                    table.ForeignKey(
                        name: "FK_ShadowSessions_People_ObservedPersonId",
                        column: x => x.ObservedPersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShadowSessions_People_ShadowerId",
                        column: x => x.ShadowerId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShadowSessions_ObservedPersonId",
                table: "ShadowSessions",
                column: "ObservedPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ShadowSessions_ShadowerId_Date",
                table: "ShadowSessions",
                columns: new[] { "ShadowerId", "Date" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShadowSessions");

            migrationBuilder.DropColumn(
                name: "ExcludedFromShadowing",
                table: "People");
        }
    }
}
