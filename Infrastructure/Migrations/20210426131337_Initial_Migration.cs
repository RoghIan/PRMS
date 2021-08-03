using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action = table.Column<string>(nullable: true),
                    Module = table.Column<string>(nullable: true),
                    DeclareDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appointed",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointed", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    OverseerPublisherId = table.Column<int>(nullable: false),
                    AssistantPublisherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BaptismDate = table.Column<DateTime>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    PhotoUrl = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    StatusId = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publishers_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Publishers_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppointedPublishers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublisherId = table.Column<int>(nullable: false),
                    AppointedId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointedPublishers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointedPublishers_Appointed_AppointedId",
                        column: x => x.AppointedId,
                        principalTable: "Appointed",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointedPublishers_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportDate = table.Column<DateTime>(nullable: false),
                    Placements = table.Column<int>(nullable: false),
                    VideoShowings = table.Column<int>(nullable: false),
                    Hours = table.Column<double>(nullable: false),
                    ReturnVisits = table.Column<int>(nullable: false),
                    BibleStudies = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    TitleName = table.Column<string>(nullable: true),
                    GroupName = table.Column<string>(nullable: true),
                    Auxiliary = table.Column<bool>(nullable: false),
                    PublisherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointedPublishers_AppointedId",
                table: "AppointedPublishers",
                column: "AppointedId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointedPublishers_PublisherId",
                table: "AppointedPublishers",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Publishers_GroupId",
                table: "Publishers",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Publishers_StatusId",
                table: "Publishers",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_PublisherId",
                table: "Reports",
                column: "PublisherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityLogs");

            migrationBuilder.DropTable(
                name: "AppointedPublishers");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Appointed");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}
