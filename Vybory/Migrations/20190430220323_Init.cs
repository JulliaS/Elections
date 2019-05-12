using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Vybory.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Region = table.Column<string>(nullable: true),
                    Town = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    HouseNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppealTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppealTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComplaintTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Number = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Center = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                    table.UniqueConstraint("AK_Districts_Name", x => x.Name);
                    table.UniqueConstraint("AK_Districts_Number", x => x.Number);
                    table.ForeignKey(
                        name: "FK_Districts_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    IPN = table.Column<int>(nullable: false),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.UniqueConstraint("AK_Users_IPN", x => x.IPN);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Elections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    TourId = table.Column<int>(nullable: true),
                    StartVote = table.Column<DateTime>(nullable: false),
                    EndVote = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Elections_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PollingStations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    AddressId = table.Column<int>(nullable: true),
                    DistrictId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollingStations", x => x.Id);
                    table.UniqueConstraint("AK_PollingStations_Name", x => x.Name);
                    table.UniqueConstraint("AK_PollingStations_Number", x => x.Number);
                    table.ForeignKey(
                        name: "FK_PollingStations_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PollingStations_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Citizens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    DistrictId = table.Column<int>(nullable: true),
                    PollingStationId = table.Column<int>(nullable: true),
                    ElectionId = table.Column<int>(nullable: true),
                    StatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citizens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Citizens_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Citizens_Elections_ElectionId",
                        column: x => x.ElectionId,
                        principalTable: "Elections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Citizens_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Citizens_PollingStations_PollingStationId",
                        column: x => x.PollingStationId,
                        principalTable: "PollingStations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Citizens_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appeals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ElectionId = table.Column<int>(nullable: true),
                    PollingStationId = table.Column<int>(nullable: true),
                    CitizenId = table.Column<int>(nullable: true),
                    AppealTypeId = table.Column<int>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appeals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appeals_AppealTypes_AppealTypeId",
                        column: x => x.AppealTypeId,
                        principalTable: "AppealTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appeals_Citizens_CitizenId",
                        column: x => x.CitizenId,
                        principalTable: "Citizens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appeals_Elections_ElectionId",
                        column: x => x.ElectionId,
                        principalTable: "Elections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appeals_PollingStations_PollingStationId",
                        column: x => x.PollingStationId,
                        principalTable: "PollingStations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Candidats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Number = table.Column<int>(nullable: false),
                    ElectionId = table.Column<int>(nullable: true),
                    CitizenId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidats", x => x.Id);
                    table.UniqueConstraint("AK_Candidats_Number", x => x.Number);
                    table.ForeignKey(
                        name: "FK_Candidats_Citizens_CitizenId",
                        column: x => x.CitizenId,
                        principalTable: "Citizens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Candidats_Elections_ElectionId",
                        column: x => x.ElectionId,
                        principalTable: "Elections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChermanOfDistricts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ElectionId = table.Column<int>(nullable: true),
                    DistrictId = table.Column<int>(nullable: true),
                    CitizenId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChermanOfDistricts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChermanOfDistricts_Citizens_CitizenId",
                        column: x => x.CitizenId,
                        principalTable: "Citizens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChermanOfDistricts_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChermanOfDistricts_Elections_ElectionId",
                        column: x => x.ElectionId,
                        principalTable: "Elections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChermanOfPollingStations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ElectionId = table.Column<int>(nullable: true),
                    PollingStationId = table.Column<int>(nullable: true),
                    CitizenId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChermanOfPollingStations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChermanOfPollingStations_Citizens_CitizenId",
                        column: x => x.CitizenId,
                        principalTable: "Citizens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChermanOfPollingStations_Elections_ElectionId",
                        column: x => x.ElectionId,
                        principalTable: "Elections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChermanOfPollingStations_PollingStations_PollingStationId",
                        column: x => x.PollingStationId,
                        principalTable: "PollingStations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Observers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ElectionId = table.Column<int>(nullable: true),
                    PollingStationId = table.Column<int>(nullable: true),
                    CitizenId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Observers_Citizens_CitizenId",
                        column: x => x.CitizenId,
                        principalTable: "Citizens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Observers_Elections_ElectionId",
                        column: x => x.ElectionId,
                        principalTable: "Elections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Observers_PollingStations_PollingStationId",
                        column: x => x.PollingStationId,
                        principalTable: "PollingStations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ElectionId = table.Column<int>(nullable: true),
                    PollingStationId = table.Column<int>(nullable: true),
                    CitizenId = table.Column<int>(nullable: true),
                    CandidatId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Votes_Candidats_CandidatId",
                        column: x => x.CandidatId,
                        principalTable: "Candidats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Votes_Citizens_CitizenId",
                        column: x => x.CitizenId,
                        principalTable: "Citizens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Votes_Elections_ElectionId",
                        column: x => x.ElectionId,
                        principalTable: "Elections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Votes_PollingStations_PollingStationId",
                        column: x => x.PollingStationId,
                        principalTable: "PollingStations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Complaints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ElectionId = table.Column<int>(nullable: true),
                    PollingStationId = table.Column<int>(nullable: true),
                    ObserverId = table.Column<int>(nullable: true),
                    ComplaintTypeId = table.Column<int>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Complaints_ComplaintTypes_ComplaintTypeId",
                        column: x => x.ComplaintTypeId,
                        principalTable: "ComplaintTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Complaints_Elections_ElectionId",
                        column: x => x.ElectionId,
                        principalTable: "Elections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Complaints_Observers_ObserverId",
                        column: x => x.ObserverId,
                        principalTable: "Observers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Complaints_PollingStations_PollingStationId",
                        column: x => x.PollingStationId,
                        principalTable: "PollingStations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appeals_AppealTypeId",
                table: "Appeals",
                column: "AppealTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Appeals_CitizenId",
                table: "Appeals",
                column: "CitizenId");

            migrationBuilder.CreateIndex(
                name: "IX_Appeals_ElectionId",
                table: "Appeals",
                column: "ElectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Appeals_PollingStationId",
                table: "Appeals",
                column: "PollingStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidats_CitizenId",
                table: "Candidats",
                column: "CitizenId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidats_ElectionId",
                table: "Candidats",
                column: "ElectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ChermanOfDistricts_CitizenId",
                table: "ChermanOfDistricts",
                column: "CitizenId");

            migrationBuilder.CreateIndex(
                name: "IX_ChermanOfDistricts_DistrictId",
                table: "ChermanOfDistricts",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_ChermanOfDistricts_ElectionId",
                table: "ChermanOfDistricts",
                column: "ElectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ChermanOfPollingStations_CitizenId",
                table: "ChermanOfPollingStations",
                column: "CitizenId");

            migrationBuilder.CreateIndex(
                name: "IX_ChermanOfPollingStations_ElectionId",
                table: "ChermanOfPollingStations",
                column: "ElectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ChermanOfPollingStations_PollingStationId",
                table: "ChermanOfPollingStations",
                column: "PollingStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Citizens_DistrictId",
                table: "Citizens",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Citizens_ElectionId",
                table: "Citizens",
                column: "ElectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Citizens_PollingStationId",
                table: "Citizens",
                column: "PollingStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Citizens_StatusId",
                table: "Citizens",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_ComplaintTypeId",
                table: "Complaints",
                column: "ComplaintTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_ElectionId",
                table: "Complaints",
                column: "ElectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_ObserverId",
                table: "Complaints",
                column: "ObserverId");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_PollingStationId",
                table: "Complaints",
                column: "PollingStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_AddressId",
                table: "Districts",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Elections_TourId",
                table: "Elections",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_Observers_CitizenId",
                table: "Observers",
                column: "CitizenId");

            migrationBuilder.CreateIndex(
                name: "IX_Observers_ElectionId",
                table: "Observers",
                column: "ElectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Observers_PollingStationId",
                table: "Observers",
                column: "PollingStationId");

            migrationBuilder.CreateIndex(
                name: "IX_PollingStations_AddressId",
                table: "PollingStations",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_PollingStations_DistrictId",
                table: "PollingStations",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_CandidatId",
                table: "Votes",
                column: "CandidatId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_CitizenId",
                table: "Votes",
                column: "CitizenId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_ElectionId",
                table: "Votes",
                column: "ElectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_PollingStationId",
                table: "Votes",
                column: "PollingStationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appeals");

            migrationBuilder.DropTable(
                name: "ChermanOfDistricts");

            migrationBuilder.DropTable(
                name: "ChermanOfPollingStations");

            migrationBuilder.DropTable(
                name: "Complaints");

            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropTable(
                name: "AppealTypes");

            migrationBuilder.DropTable(
                name: "ComplaintTypes");

            migrationBuilder.DropTable(
                name: "Observers");

            migrationBuilder.DropTable(
                name: "Candidats");

            migrationBuilder.DropTable(
                name: "Citizens");

            migrationBuilder.DropTable(
                name: "Elections");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "PollingStations");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Tours");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
