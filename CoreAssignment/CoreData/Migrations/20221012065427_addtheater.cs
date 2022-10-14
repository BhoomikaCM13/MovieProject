using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreData.Migrations
{
    public partial class addtheater : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "theaters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_theaters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "showTimings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MId = table.Column<int>(type: "int", nullable: false),
                    TId = table.Column<int>(type: "int", nullable: false),
                    ShowTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_showTimings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_showTimings_movies_MId",
                        column: x => x.MId,
                        principalTable: "movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_showTimings_theaters_TId",
                        column: x => x.TId,
                        principalTable: "theaters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_showTimings_MId",
                table: "showTimings",
                column: "MId");

            migrationBuilder.CreateIndex(
                name: "IX_showTimings_TId",
                table: "showTimings",
                column: "TId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "showTimings");

            migrationBuilder.DropTable(
                name: "theaters");
        }
    }
}
