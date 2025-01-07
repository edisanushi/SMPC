using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class creating_table_SMPCCase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SMPC_Cases",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDSMPC_Call_Types = table.Column<int>(type: "int", nullable: false),
                    Caller_Name = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    Caller_Phone = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    Address = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    Description = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    IDSMPC_Caller = table.Column<int>(type: "int", nullable: false),
                    IDSMPC_Call_Reason = table.Column<int>(type: "int", nullable: false),
                    OrgID = table.Column<int>(type: "int", nullable: false),
                    IDSMPC_Coverage_Zone = table.Column<int>(type: "int", nullable: false),
                    IsForSupervisor = table.Column<byte>(type: "tinyint", nullable: false),
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
                    table.PrimaryKey("PK_SMPC_Cases", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SMPC_Cases_SMPC_Call_Reason_IDSMPC_Call_Reason",
                        column: x => x.IDSMPC_Call_Reason,
                        principalTable: "SMPC_Call_Reason",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SMPC_Cases_SMPC_Call_Types_IDSMPC_Call_Types",
                        column: x => x.IDSMPC_Call_Types,
                        principalTable: "SMPC_Call_Types",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SMPC_Cases_SMPC_Caller_IDSMPC_Caller",
                        column: x => x.IDSMPC_Caller,
                        principalTable: "SMPC_Caller",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SMPC_Cases_SMPC_Organigram_OrgID",
                        column: x => x.OrgID,
                        principalTable: "SMPC_Organigram",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SMPC_Cases_SMPC_Zone_IDSMPC_Coverage_Zone",
                        column: x => x.IDSMPC_Coverage_Zone,
                        principalTable: "SMPC_Zone",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SMPC_Cases_IDSMPC_Call_Reason",
                table: "SMPC_Cases",
                column: "IDSMPC_Call_Reason");

            migrationBuilder.CreateIndex(
                name: "IX_SMPC_Cases_IDSMPC_Call_Types",
                table: "SMPC_Cases",
                column: "IDSMPC_Call_Types");

            migrationBuilder.CreateIndex(
                name: "IX_SMPC_Cases_IDSMPC_Caller",
                table: "SMPC_Cases",
                column: "IDSMPC_Caller");

            migrationBuilder.CreateIndex(
                name: "IX_SMPC_Cases_IDSMPC_Coverage_Zone",
                table: "SMPC_Cases",
                column: "IDSMPC_Coverage_Zone");

            migrationBuilder.CreateIndex(
                name: "IX_SMPC_Cases_OrgID",
                table: "SMPC_Cases",
                column: "OrgID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SMPC_Cases");
        }
    }
}
