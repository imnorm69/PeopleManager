using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeopleManager.Migrations
{
    /// <inheritdoc />
    public partial class BackfillObservedName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Backfill from the link that was previously required, so existing rows keep a display name.
            migrationBuilder.Sql(
                "UPDATE \"ShadowSessions\" SET \"ObservedName\" = " +
                "(SELECT \"LastName\" || ', ' || \"FirstName\" FROM \"People\" WHERE \"PersonId\" = \"ShadowSessions\".\"ObservedPersonId\") " +
                "WHERE \"ObservedPersonId\" IS NOT NULL;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
