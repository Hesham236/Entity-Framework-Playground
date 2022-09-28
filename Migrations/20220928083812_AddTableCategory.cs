using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity_Framework_Playground.Migrations
{
    public partial class AddTableCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AuditEntery",
                table: "AuditEntery");

            migrationBuilder.RenameTable(
                name: "AuditEntery",
                newName: "Auditenteries");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Auditenteries",
                table: "Auditenteries",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Auditenteries",
                table: "Auditenteries");

            migrationBuilder.RenameTable(
                name: "Auditenteries",
                newName: "AuditEntery");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuditEntery",
                table: "AuditEntery",
                column: "Id");
        }
    }
}
