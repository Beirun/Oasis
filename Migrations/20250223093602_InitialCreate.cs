using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oasis.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    guest_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    guest_fname = table.Column<string>(type: "TEXT", nullable: true),
                    guest_lname = table.Column<string>(type: "TEXT", nullable: true),
                    guest_email = table.Column<string>(type: "TEXT", nullable: true),
                    guest_gender = table.Column<string>(type: "TEXT", nullable: true),
                    guest_password = table.Column<string>(type: "TEXT", nullable: true),
                    guest_contactno = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.guest_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guests");
        }
    }
}
