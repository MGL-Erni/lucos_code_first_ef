using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lucos_code_first_ef.Migrations
{
    /// <inheritdoc />
    public partial class FixedCascadePathsWithJsonIgnoreFKsAndOnModelCreating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Openings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OpeningName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Openings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerRating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerWId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerBId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OpeningId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Openings_OpeningId",
                        column: x => x.OpeningId,
                        principalTable: "Openings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Games_Players_PlayerBId",
                        column: x => x.PlayerBId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Games_Players_PlayerWId",
                        column: x => x.PlayerWId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_OpeningId",
                table: "Games",
                column: "OpeningId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_PlayerBId",
                table: "Games",
                column: "PlayerBId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_PlayerWId",
                table: "Games",
                column: "PlayerWId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Openings");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
