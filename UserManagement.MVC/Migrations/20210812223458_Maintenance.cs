using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheDeepOTools.Migrations
{
    public partial class Maintenance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Maintenance",
                schema: "Identity",
                columns: table => new
                {
                    ItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemIdentifier = table.Column<string>(nullable: false),
                    ItemName = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Category = table.Column<string>(nullable: false),
                    Subcategory = table.Column<string>(nullable: true),
                    ServiceHrs = table.Column<DateTime>(nullable: false),
                    TotalHrs = table.Column<DateTime>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    StopTime = table.Column<DateTime>(nullable: false),
                    IsInService = table.Column<bool>(nullable: false),
                    NeedsMaintaince = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenance", x => x.ItemID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Maintenance",
                schema: "Identity");
        }
    }
}
