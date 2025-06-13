using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Balance = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ledgers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ledgers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ledgers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Balance", "CreatedAt", "Username" },
                values: new object[,]
                {
                    { new Guid("4585ce1a-5a9d-4af8-9829-92490bb9f2a3"), 10000m, new DateTime(2024, 6, 13, 0, 0, 0, 0, DateTimeKind.Utc), "John" },
                    { new Guid("a0c167f1-3d60-4e8d-8b46-114db223284f"), 256698m, new DateTime(2024, 6, 13, 0, 0, 0, 0, DateTimeKind.Utc), "Jane" },
                    { new Guid("b175f222-de5d-473c-af2c-59a713bf4c95"), 500000m, new DateTime(2024, 6, 13, 0, 0, 0, 0, DateTimeKind.Utc), "Rich" },
                    { new Guid("c21feb91-5cbb-4f8a-884a-0597444e7bb2"), 0m, new DateTime(2024, 6, 13, 0, 0, 0, 0, DateTimeKind.Utc), "Brokey" },
                    { new Guid("d39375a6-43f7-4bee-ae3f-745ccde7eac4"), 25605.5m, new DateTime(2024, 6, 13, 0, 0, 0, 0, DateTimeKind.Utc), "Sam" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ledgers_UserId",
                table: "Ledgers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ledgers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
