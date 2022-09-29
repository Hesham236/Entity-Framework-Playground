using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity_Framework_Playground.Migrations
{
    public partial class allisback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Blogs_BlogsId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_BlogsId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "BlogsId",
                table: "Posts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogsId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_BlogsId",
                table: "Posts",
                column: "BlogsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Blogs_BlogsId",
                table: "Posts",
                column: "BlogsId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
