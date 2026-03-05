using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StargateAPI.Business.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAstronautDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AstronautDuty_PersonId",
                table: "AstronautDuty");

            migrationBuilder.DropIndex(
                name: "IX_AstronautDetail_PersonId",
                table: "AstronautDetail");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CareerStartDate",
                table: "AstronautDetail",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_Name",
                table: "Person",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AstronautDuty_PersonId",
                table: "AstronautDuty",
                column: "PersonId",
                unique: true,
                filter: "DutyEndDate IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AstronautDetail_PersonId",
                table: "AstronautDetail",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Person_Name",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_AstronautDuty_PersonId",
                table: "AstronautDuty");

            migrationBuilder.DropIndex(
                name: "IX_AstronautDetail_PersonId",
                table: "AstronautDetail");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CareerStartDate",
                table: "AstronautDetail",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.CreateIndex(
                name: "IX_AstronautDuty_PersonId",
                table: "AstronautDuty",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_AstronautDetail_PersonId",
                table: "AstronautDetail",
                column: "PersonId",
                unique: true);
        }
    }
}
