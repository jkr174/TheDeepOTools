using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheDeepOTools.Migrations.TheDeepOTools
{
    public partial class RepairTicketDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    UsernameChangeLimit = table.Column<int>(nullable: false),
                    ProfilePicture = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RepairTicket",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TicketState = table.Column<string>(nullable: true),
                    OwnerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairTicket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepairTicket_ApplicationUser_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RepairTicketMessage",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    TicketId = table.Column<Guid>(nullable: false),
                    OwnerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairTicketMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepairTicketMessage_ApplicationUser_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RepairTicketMessage_RepairTicket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "RepairTicket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RepairTicket_OwnerId",
                table: "RepairTicket",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairTicketMessage_OwnerId",
                table: "RepairTicketMessage",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairTicketMessage_TicketId",
                table: "RepairTicketMessage",
                column: "TicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RepairTicketMessage");

            migrationBuilder.DropTable(
                name: "RepairTicket");

            migrationBuilder.DropTable(
                name: "ApplicationUser");
        }
    }
}
