using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DndTrackerApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DndTracker",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CharacterName = table.Column<string>(type: "TEXT", nullable: false),
                    CharacterClass = table.Column<string>(type: "TEXT", nullable: false),
                    CharacterLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrentXp = table.Column<int>(type: "INTEGER", nullable: false),
                    ActiveCampaign = table.Column<bool>(type: "INTEGER", nullable: false),
                    SessionOneDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastSessionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DndTracker", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DndTracker");
        }
    }
}
