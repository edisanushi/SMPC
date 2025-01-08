using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SMPCClosedCase_SMPCConnection_SMPCConsequences_SMPCCooperation_SMPCUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SMPC_Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDOrg = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    Password = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    isActive = table.Column<byte>(type: "tinyint", nullable: false),
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
                    table.PrimaryKey("PK_SMPC_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SMPC_Users_SMPC_Organigram_IDOrg",
                        column: x => x.IDOrg,
                        principalTable: "SMPC_Organigram",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SMPC_Closed_Cases",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDSMPC_Verification = table.Column<int>(type: "int", nullable: false),
                    VerificationDescription = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    isComplaint = table.Column<byte>(type: "tinyint", nullable: false),
                    IDSMPC_VerificatonRsult = table.Column<int>(type: "int", nullable: false),
                    IDSMPC_Case = table.Column<int>(type: "int", nullable: false),
                    UniqueNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Invalidated = table.Column<byte>(type: "tinyint", nullable: false),
                    UniqueNumberDescription = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    DeactivationUNDescription = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Id_UN_User = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMPC_Closed_Cases", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SMPC_Closed_Cases_SMPC_Call_Reason_IDSMPC_VerificatonRsult",
                        column: x => x.IDSMPC_VerificatonRsult,
                        principalTable: "SMPC_Call_Reason",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SMPC_Closed_Cases_SMPC_Call_Types_IDSMPC_Verification",
                        column: x => x.IDSMPC_Verification,
                        principalTable: "SMPC_Call_Types",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SMPC_Closed_Cases_SMPC_Cases_IDSMPC_Case",
                        column: x => x.IDSMPC_Case,
                        principalTable: "SMPC_Cases",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_SMPC_Closed_Cases_SMPC_Users_Id_UN_User",
                        column: x => x.Id_UN_User,
                        principalTable: "SMPC_Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SMPC_Closed_Cases_Id_UN_User",
                table: "SMPC_Closed_Cases",
                column: "Id_UN_User");

            migrationBuilder.CreateIndex(
                name: "IX_SMPC_Closed_Cases_IDSMPC_Case",
                table: "SMPC_Closed_Cases",
                column: "IDSMPC_Case");

            migrationBuilder.CreateIndex(
                name: "IX_SMPC_Closed_Cases_IDSMPC_Verification",
                table: "SMPC_Closed_Cases",
                column: "IDSMPC_Verification");

            migrationBuilder.CreateIndex(
                name: "IX_SMPC_Closed_Cases_IDSMPC_VerificatonRsult",
                table: "SMPC_Closed_Cases",
                column: "IDSMPC_VerificatonRsult");

            migrationBuilder.CreateIndex(
                name: "IX_SMPC_Users_IDOrg",
                table: "SMPC_Users",
                column: "IDOrg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SMPC_Closed_Cases");

            migrationBuilder.DropTable(
                name: "SMPC_Users");
        }
    }
}
