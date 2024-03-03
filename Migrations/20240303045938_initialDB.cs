using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace golden_snitch.Migrations
{
    /// <inheritdoc />
    public partial class initialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Action",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDateUTC = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastModifiedDateUTC = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    TimeZone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "Australia/Melbourne")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Action", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDateUTC = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastModifiedDateUTC = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    TimeZone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "Australia/Melbourne")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDateUTC = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastModifiedDateUTC = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    TimeZone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "Australia/Melbourne")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketTag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDateUTC = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastModifiedDateUTC = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    TimeZone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "Australia/Melbourne")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketTag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    PrivilegeLevel = table.Column<int>(type: "int", nullable: false),
                    CreationDateUTC = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastModifiedDateUTC = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    TimeZone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "Australia/Melbourne")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    WorkDays = table.Column<string>(type: "varchar(7)", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    JobTagId = table.Column<int>(type: "int", nullable: false),
                    CreationDateUTC = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastModifiedDateUTC = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    TimeZone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "Australia/Melbourne")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_JobTags_JobTagId",
                        column: x => x.JobTagId,
                        principalTable: "JobTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClaimSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CreationDateUTC = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastModifiedDateUTC = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    TimeZone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "Australia/Melbourne")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClaimSet_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DueDateUTC = table.Column<DateTime>(type: "datetime", nullable: true),
                    TicketTagId = table.Column<int>(type: "int", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: true),
                    CreationDateUTC = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastModifiedDateUTC = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    TimeZone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "Australia/Melbourne")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_TicketTag_TicketTagId",
                        column: x => x.TicketTagId,
                        principalTable: "TicketTag",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Tickets stands for the tasks with description and other props");

            migrationBuilder.CreateTable(
                name: "Claim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionId = table.Column<int>(type: "int", nullable: false),
                    ClaimSetId = table.Column<int>(type: "int", nullable: true),
                    CreationDateUTC = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastModifiedDateUTC = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    TimeZone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "Australia/Melbourne")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Claim_Action_ActionId",
                        column: x => x.ActionId,
                        principalTable: "Action",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Claim_ClaimSet_ClaimSetId",
                        column: x => x.ClaimSetId,
                        principalTable: "ClaimSet",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TicketComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    CreationDateUTC = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastModifiedDateUTC = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    TimeZone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "Australia/Melbourne")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketComments_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<int>(type: "int", nullable: false),
                    Log = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkingDateUTC = table.Column<DateTime>(type: "datetime", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    CreationDateUTC = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastModifiedDateUTC = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    TimeZone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "Australia/Melbourne")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketTags_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreationDateUTC", "Email", "LastModifiedDateUTC", "Name", "PrivilegeLevel" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 3, 4, 59, 38, 517, DateTimeKind.Utc).AddTicks(7509), "*******", new DateTime(2024, 3, 3, 4, 59, 38, 517, DateTimeKind.Utc).AddTicks(7510), "Super Admin", 3 },
                    { 2, new DateTime(2024, 3, 3, 4, 59, 38, 517, DateTimeKind.Utc).AddTicks(7512), "*******", new DateTime(2024, 3, 3, 4, 59, 38, 517, DateTimeKind.Utc).AddTicks(7512), "Weiss", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Claim_ActionId",
                table: "Claim",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_Claim_ClaimSetId",
                table: "Claim",
                column: "ClaimSetId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimSet_UserId",
                table: "ClaimSet",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_JobTagId",
                table: "Jobs",
                column: "JobTagId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ProjectId",
                table: "Jobs",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketComments_TicketId",
                table: "TicketComments",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_JobId",
                table: "Tickets",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_OwnerId",
                table: "Tickets",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketTagId",
                table: "Tickets",
                column: "TicketTagId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketTags_TicketId",
                table: "TicketTags",
                column: "TicketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Claim");

            migrationBuilder.DropTable(
                name: "TicketComments");

            migrationBuilder.DropTable(
                name: "TicketTags");

            migrationBuilder.DropTable(
                name: "Action");

            migrationBuilder.DropTable(
                name: "ClaimSet");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "TicketTag");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "JobTags");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
