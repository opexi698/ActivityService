using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActivityService.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedActivity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Activities",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Activities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Activities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                table: "Activities",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Activities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CreatedBy",
                table: "Activities",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_UpdateBy",
                table: "Activities",
                column: "UpdateBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_AspNetUsers_CreatedBy",
                table: "Activities",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_AspNetUsers_UpdateBy",
                table: "Activities",
                column: "UpdateBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_AspNetUsers_CreatedBy",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_AspNetUsers_UpdateBy",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_CreatedBy",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_UpdateBy",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Activities");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
