using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeopleManager.Migrations
{
    /// <inheritdoc />
    public partial class AddShadowEventTypeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EventType",
                table: "ShadowSessions",
                newName: "EventTypeId");

            migrationBuilder.CreateTable(
                name: "ShadowEventTypes",
                columns: table => new
                {
                    ShadowEventTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Points = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShadowEventTypes", x => x.ShadowEventTypeId);
                });

            // Seed with explicit Ids 1-6, matching (old enum value + 1) so the data
            // backfill below can simply shift the old 0-based EventTypeId values by 1.
            migrationBuilder.Sql(
                "INSERT INTO \"ShadowEventTypes\" (\"ShadowEventTypeId\", \"Name\", \"Points\", \"IsActive\") VALUES " +
                "(1, 'Planning', '1', 1), " +
                "(2, 'Refinement', '1', 1), " +
                "(3, 'Review', '1', 1), " +
                "(4, 'Retro', '1', 1), " +
                "(5, 'Daily Standup', '0.5', 1), " +
                "(6, 'Other', '1', 1);");

            // The old EventType column stored the enum's 0-based ordinal
            // (Planning=0 .. Other=5); shift to match the new 1-based Ids above.
            migrationBuilder.Sql(
                "UPDATE \"ShadowSessions\" SET \"EventTypeId\" = \"EventTypeId\" + 1;");

            migrationBuilder.CreateIndex(
                name: "IX_ShadowSessions_EventTypeId",
                table: "ShadowSessions",
                column: "EventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShadowEventTypes_Name",
                table: "ShadowEventTypes",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShadowSessions_ShadowEventTypes_EventTypeId",
                table: "ShadowSessions",
                column: "EventTypeId",
                principalTable: "ShadowEventTypes",
                principalColumn: "ShadowEventTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShadowSessions_ShadowEventTypes_EventTypeId",
                table: "ShadowSessions");

            migrationBuilder.DropIndex(
                name: "IX_ShadowSessions_EventTypeId",
                table: "ShadowSessions");

            migrationBuilder.Sql(
                "UPDATE \"ShadowSessions\" SET \"EventTypeId\" = \"EventTypeId\" - 1;");

            migrationBuilder.DropTable(
                name: "ShadowEventTypes");

            migrationBuilder.RenameColumn(
                name: "EventTypeId",
                table: "ShadowSessions",
                newName: "EventType");
        }
    }
}
