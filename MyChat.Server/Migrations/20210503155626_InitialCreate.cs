using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyChat.Server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    identifier = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    avatar = table.Column<string>(type: "TEXT", nullable: true),
                    socketId = table.Column<string>(type: "TEXT", nullable: true),
                    roomid = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                    table.ForeignKey(
                        name: "FK_Users_Rooms_roomid",
                        column: x => x.roomid,
                        principalTable: "Rooms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    text = table.Column<string>(type: "TEXT", nullable: true),
                    stamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    userid = table.Column<Guid>(type: "TEXT", nullable: true),
                    roomid = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.id);
                    table.ForeignKey(
                        name: "FK_Messages_Rooms_roomid",
                        column: x => x.roomid,
                        principalTable: "Rooms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_Users_userid",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_roomid",
                table: "Messages",
                column: "roomid");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_userid",
                table: "Messages",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_Users_roomid",
                table: "Users",
                column: "roomid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
