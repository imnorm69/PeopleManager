using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeopleManager.Migrations
{
    /// <inheritdoc />
    public partial class AddShadowRequirements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExcludedFromShadowing",
                table: "People");

            migrationBuilder.AlterColumn<decimal>(
                name: "Points",
                table: "ShadowSessions",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AddColumn<decimal>(
                name: "ShadowPointRequirement",
                table: "People",
                type: "TEXT",
                nullable: false,
                defaultValue: 2m);

            migrationBuilder.CreateTable(
                name: "AppSettings",
                columns: table => new
                {
                    AppSettingsId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ShadowRequirementsEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    DefaultShadowPointRequirement = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSettings", x => x.AppSettingsId);
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "AppSettingsId", "ShadowRequirementsEnabled", "DefaultShadowPointRequirement" },
                values: new object[] { 1, true, 2m });

            migrationBuilder.CreateTable(
                name: "PersonShadowRequirements",
                columns: table => new
                {
                    PersonShadowRequirementId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    Quarter = table.Column<int>(type: "INTEGER", nullable: false),
                    RequiredPoints = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonShadowRequirements", x => x.PersonShadowRequirementId);
                    table.ForeignKey(
                        name: "FK_PersonShadowRequirements_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonShadowRequirements_PersonId_Year_Quarter",
                table: "PersonShadowRequirements",
                columns: new[] { "PersonId", "Year", "Quarter" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppSettings");

            migrationBuilder.DropTable(
                name: "PersonShadowRequirements");

            migrationBuilder.DropColumn(
                name: "ShadowPointRequirement",
                table: "People");

            migrationBuilder.AlterColumn<decimal>(
                name: "Points",
                table: "ShadowSessions",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ExcludedFromShadowing",
                table: "People",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
