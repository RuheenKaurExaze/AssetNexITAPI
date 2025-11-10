using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetNex.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSofwareLicenseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupportReqs_AssetTypes_AssetTypeId",
                table: "SupportReqs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SupportReqs",
                table: "SupportReqs");

            migrationBuilder.DropIndex(
                name: "IX_SupportReqs_AssetTypeId",
                table: "SupportReqs");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "SoftwareLicenseInfo");

            migrationBuilder.DropColumn(
                name: "Request",
                table: "SoftwareLicenseInfo");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "SoftwareLicenseInfo");

            migrationBuilder.DropColumn(
                name: "AssetTypeId",
                table: "SupportReqs");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "SupportReqs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SupportReqs");

            migrationBuilder.RenameTable(
                name: "SupportReqs",
                newName: "SupportRequests");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "SupportRequests",
                newName: "SoftwareName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "SupportRequests",
                newName: "RequestType");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "SupportRequests",
                newName: "OtherSoftware");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "SupportRequests",
                newName: "EmployeeId");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "SupportRequests",
                newName: "Department");

            migrationBuilder.AlterColumn<string>(
                name: "OtherSoftware",
                table: "SoftwareLicenseInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SupportRequestId",
                table: "SoftwareLicenseInfo",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "SupportRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SupportRequests",
                table: "SupportRequests",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareLicenseInfo_SupportRequestId",
                table: "SoftwareLicenseInfo",
                column: "SupportRequestId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SoftwareLicenseInfo_SupportRequests_SupportRequestId",
                table: "SoftwareLicenseInfo",
                column: "SupportRequestId",
                principalTable: "SupportRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoftwareLicenseInfo_SupportRequests_SupportRequestId",
                table: "SoftwareLicenseInfo");

            migrationBuilder.DropIndex(
                name: "IX_SoftwareLicenseInfo_SupportRequestId",
                table: "SoftwareLicenseInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SupportRequests",
                table: "SupportRequests");

            migrationBuilder.DropColumn(
                name: "SupportRequestId",
                table: "SoftwareLicenseInfo");

            migrationBuilder.RenameTable(
                name: "SupportRequests",
                newName: "SupportReqs");

            migrationBuilder.RenameColumn(
                name: "SoftwareName",
                table: "SupportReqs",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "RequestType",
                table: "SupportReqs",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "OtherSoftware",
                table: "SupportReqs",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "SupportReqs",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Department",
                table: "SupportReqs",
                newName: "Category");

            migrationBuilder.AlterColumn<string>(
                name: "OtherSoftware",
                table: "SoftwareLicenseInfo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "SoftwareLicenseInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Request",
                table: "SoftwareLicenseInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "SoftwareLicenseInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "SupportReqs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "AssetTypeId",
                table: "SupportReqs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "SupportReqs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "SupportReqs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SupportReqs",
                table: "SupportReqs",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SupportReqs_AssetTypeId",
                table: "SupportReqs",
                column: "AssetTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SupportReqs_AssetTypes_AssetTypeId",
                table: "SupportReqs",
                column: "AssetTypeId",
                principalTable: "AssetTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
