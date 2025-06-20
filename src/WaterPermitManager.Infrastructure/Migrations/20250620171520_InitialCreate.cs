using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WaterPermitManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WaterPermits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermitNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacilityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacilityAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    WaterSourceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AllowedDailyDischarge = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    DischargeUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssuingAuthority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterPermits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PermitParameters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LimitValue = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonitoringFrequency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SampleType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WaterPermitId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermitParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermitParameters_WaterPermits_WaterPermitId",
                        column: x => x.WaterPermitId,
                        principalTable: "WaterPermits",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PermitParameters_WaterPermitId",
                table: "PermitParameters",
                column: "WaterPermitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermitParameters");

            migrationBuilder.DropTable(
                name: "WaterPermits");
        }
    }
}
