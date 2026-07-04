using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeopleManager.Migrations
{
    /// <inheritdoc />
    public partial class RemoveObservedPersonId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShadowSessions_People_ObservedPersonId",
                table: "ShadowSessions");

            migrationBuilder.DropIndex(
                name: "IX_ShadowSessions_ObservedPersonId",
                table: "ShadowSessions");

            migrationBuilder.DropColumn(
                name: "ObservedPersonId",
                table: "ShadowSessions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ObservedPersonId",
                table: "ShadowSessions",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShadowSessions_ObservedPersonId",
                table: "ShadowSessions",
                column: "ObservedPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShadowSessions_People_ObservedPersonId",
                table: "ShadowSessions",
                column: "ObservedPersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
