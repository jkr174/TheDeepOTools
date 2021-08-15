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
                    Description = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Subcategory = table.Column<string>(nullable: true),
                    ServiceHrs = table.Column<TimeSpan>(nullable: true),
                    TotalHrs = table.Column<TimeSpan>(nullable: true),
                    ReqMaintenanceHrs = table.Column<TimeSpan>(nullable: true),
                    HrsSinceLastService = table.Column<TimeSpan>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: true),
                    StopTime = table.Column<DateTime>(nullable: true),
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
