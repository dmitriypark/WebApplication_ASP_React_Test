using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication_ASP_React_Test.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    orderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    citySender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    addressSender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cityRecipient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    addressRecipient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    weight = table.Column<double>(type: "float", nullable: false),
                    dateTaken = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.orderId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
