using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity_Framework_Playground.Migrations
{
    public partial class AddColumnAddon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Addedon",
                table: "Blogs",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Addedon",
                table: "Blogs");
        }
    }
}
