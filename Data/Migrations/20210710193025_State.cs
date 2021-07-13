using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheDeepOWebApp.Data.Migrations
{
    public partial class State : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    State = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.State);
                });

            migrationBuilder.CreateTable(
                name: "RepairTickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    State = table.Column<byte>(nullable: false),
                    OwnerId = table.Column<string>(nullable: true),
                    OwnerState = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairTickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepairTickets_ApplicationUser_OwnerState",
                        column: x => x.OwnerState,
                        principalTable: "ApplicationUser",
                        principalColumn: "State",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RepairTicketMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    TicketId = table.Column<Guid>(nullable: false),
                    OwnerId = table.Column<string>(nullable: true),
                    OwnerState = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairTicketMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepairTicketMessages_ApplicationUser_OwnerState",
                        column: x => x.OwnerState,
                        principalTable: "ApplicationUser",
                        principalColumn: "State",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RepairTicketMessages_RepairTickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "RepairTickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RepairTicketMessages_OwnerState",
                table: "RepairTicketMessages",
                column: "OwnerState");

            migrationBuilder.CreateIndex(
                name: "IX_RepairTicketMessages_TicketId",
                table: "RepairTicketMessages",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairTickets_OwnerState",
                table: "RepairTickets",
                column: "OwnerState");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RepairTicketMessages");

            migrationBuilder.DropTable(
                name: "RepairTickets");

            migrationBuilder.DropTable(
                name: "ApplicationUser");
        }
    }
}
