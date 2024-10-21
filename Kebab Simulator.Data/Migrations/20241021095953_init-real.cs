using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kebab_Simulator.Data.Migrations
{
    /// <inheritdoc />
    public partial class initreal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kebabs",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KebabName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KebabXP = table.Column<int>(type: "int", nullable: false),
                    KebabXPNextLevel = table.Column<int>(type: "int", nullable: false),
                    KebabLevel = table.Column<int>(type: "int", nullable: false),
                    KebabFoods = table.Column<int>(type: "int", nullable: false),
                    KebabType = table.Column<int>(type: "int", nullable: false),
                    Checkout = table.Column<int>(type: "int", nullable: false),
                    KebabBankAccount = table.Column<int>(type: "int", nullable: false),
                    KebabStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KebabDone = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KebabStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kebabs", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kebabs");
        }
    }
}
