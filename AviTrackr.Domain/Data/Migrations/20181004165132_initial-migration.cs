using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AviTrackr.Domain.Data.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyTaskStatuses",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Identifier = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "getdate()"),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    StatusName = table.Column<string>(nullable: true),
                    StatusDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyTaskStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotificationTimings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Identifier = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "getdate()"),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    TimingAmount = table.Column<int>(nullable: false),
                    TimingAmountType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationTimings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotificationTypes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Identifier = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "getdate()"),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    NotificationTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Identifier = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "getdate()"),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    HasLoggedIn = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Identifier = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "getdate()"),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    TaskName = table.Column<string>(nullable: true),
                    TaskDescription = table.Column<string>(nullable: true),
                    ShowBusy = table.Column<bool>(nullable: false),
                    IsVisible = table.Column<bool>(nullable: false),
                    StartsAt = table.Column<DateTime>(nullable: true),
                    ExpiresAt = table.Column<DateTime>(nullable: true),
                    UserProfileId = table.Column<long>(nullable: false),
                    StatusId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_MyTaskStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "MyTaskStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPermissions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Identifier = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "getdate()"),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UserProfileId = table.Column<long>(nullable: false),
                    ProjectId = table.Column<int>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPermissions_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotifcationLocations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Identifier = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "getdate()"),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Location = table.Column<string>(nullable: true),
                    ListingBoundsNorthEastLatitude = table.Column<double>(nullable: true),
                    ListingBoundsNorthEastLongitude = table.Column<double>(nullable: true),
                    ListingBoundsSouthWestLatitude = table.Column<double>(nullable: true),
                    ListingBoundsSouthWesttLongitude = table.Column<double>(nullable: true),
                    MyTaskId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotifcationLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotifcationLocations_Tasks_MyTaskId",
                        column: x => x.MyTaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Identifier = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "getdate()"),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    NotificationTypeId = table.Column<long>(nullable: false),
                    NotificationTimingId = table.Column<long>(nullable: false),
                    MyTaskId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Tasks_MyTaskId",
                        column: x => x.MyTaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notifications_NotificationTimings_NotificationTimingId",
                        column: x => x.NotificationTimingId,
                        principalTable: "NotificationTimings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notifications_NotificationTypes_NotificationTypeId",
                        column: x => x.NotificationTypeId,
                        principalTable: "NotificationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotifcationLocations_MyTaskId",
                table: "NotifcationLocations",
                column: "MyTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_MyTaskId",
                table: "Notifications",
                column: "MyTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_NotificationTimingId",
                table: "Notifications",
                column: "NotificationTimingId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_NotificationTypeId",
                table: "Notifications",
                column: "NotificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_StatusId",
                table: "Tasks",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserProfileId",
                table: "Tasks",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissions_UserProfileId",
                table: "UserPermissions",
                column: "UserProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotifcationLocations");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "UserPermissions");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "NotificationTimings");

            migrationBuilder.DropTable(
                name: "NotificationTypes");

            migrationBuilder.DropTable(
                name: "MyTaskStatuses");

            migrationBuilder.DropTable(
                name: "UserProfiles");
        }
    }
}
