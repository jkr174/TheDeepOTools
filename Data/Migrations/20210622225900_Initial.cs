using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheDeepOWebApp.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    ItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemIdentifier = table.Column<string>(nullable: false),
                    ItemName = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Category = table.Column<string>(nullable: false),
                    Subcategory = table.Column<string>(nullable: true),
                    OnHandQty = table.Column<int>(nullable: false),
                    OutQty = table.Column<int>(nullable: false),
                    TotalQty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.ItemID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory");
        }
    }
}
