using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cone.InventoryManagement.Persistence.Migrations
{
    public partial class LaptopUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblMapClientConnection",
                columns: table => new
                {
                    intClientConnectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    intClientSetupId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "0"),
                    bytConnectionType = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "0"),
                    txtKey = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true),
                    txtUsername = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    txtPassword = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    txtPort = table.Column<string>(type: "VARCHAR(5)", maxLength: 5, nullable: true),
                    dtDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    dtLastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMapClientConnection", x => x.intClientConnectionId);
                });

            migrationBuilder.CreateTable(
                name: "tblMapClientFile",
                columns: table => new
                {
                    intClientFileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    intClientSetupId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "0"),
                    bytFileType = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "0"),
                    blnFileColumnRequired = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    blnReferenceNumber = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    txtFileColumn = table.Column<string>(type: "VARCHAR(35)", maxLength: 35, nullable: true),
                    txtMapWithNode = table.Column<string>(type: "VARCHAR(35)", maxLength: 35, nullable: true),
                    dtDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    dtLastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMapClientFile", x => x.intClientFileId);
                });

            migrationBuilder.CreateTable(
                name: "tblMapClientSetup",
                columns: table => new
                {
                    intClientSetupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bytStatus = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "0"),
                    txtClientName = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    txtClientId = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: false),
                    txtFolderLocation = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    txtProcessedFolderLocation = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    dtDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMapClientSetup", x => x.intClientSetupId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblMapClientConnection");

            migrationBuilder.DropTable(
                name: "tblMapClientFile");

            migrationBuilder.DropTable(
                name: "tblMapClientSetup");
        }
    }
}
