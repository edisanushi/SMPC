using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SMPCCriminalOffense_SMPCDistributedCases_SMPCDrugType_SMPCEthnicity_SMPCEventReason : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SMPC_Connection",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Invalidated = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMPC_Connection", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SMPC_Consequences",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Invalidated = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMPC_Consequences", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Smpc_Cooporation_type",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Invalidated = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smpc_Cooporation_type", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SMPC_Criminal_Offense",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    parentId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Invalidated = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMPC_Criminal_Offense", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SMPC_Distributed_Cases",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDSMPC_Case = table.Column<int>(type: "int", nullable: false),
                    IDSMPC_Coverage_Zone = table.Column<int>(type: "int", nullable: false),
                    NotfiedPatrol = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    VerificationPatrol = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    CallDescription = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    VerificationDescription = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    Orders = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    ChangedZoneDescription = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Invalidated = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMPC_Distributed_Cases", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SMPC_Distributed_Cases_SMPC_Cases_IDSMPC_Case",
                        column: x => x.IDSMPC_Case,
                        principalTable: "SMPC_Cases",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_SMPC_Distributed_Cases_SMPC_Zone_IDSMPC_Coverage_Zone",
                        column: x => x.IDSMPC_Coverage_Zone,
                        principalTable: "SMPC_Zone",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SMPC_DrugType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    parentId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Invalidated = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMPC_DrugType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SMPC_Ethnicity",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Invalidated = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMPC_Ethnicity", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SMPC_EventReason",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Invalidated = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMPC_EventReason", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SMPC_Distributed_Cases_IDSMPC_Case",
                table: "SMPC_Distributed_Cases",
                column: "IDSMPC_Case");

            migrationBuilder.CreateIndex(
                name: "IX_SMPC_Distributed_Cases_IDSMPC_Coverage_Zone",
                table: "SMPC_Distributed_Cases",
                column: "IDSMPC_Coverage_Zone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SMPC_Connection");

            migrationBuilder.DropTable(
                name: "SMPC_Consequences");

            migrationBuilder.DropTable(
                name: "Smpc_Cooporation_type");

            migrationBuilder.DropTable(
                name: "SMPC_Criminal_Offense");

            migrationBuilder.DropTable(
                name: "SMPC_Distributed_Cases");

            migrationBuilder.DropTable(
                name: "SMPC_DrugType");

            migrationBuilder.DropTable(
                name: "SMPC_Ethnicity");

            migrationBuilder.DropTable(
                name: "SMPC_EventReason");
        }
    }
}
