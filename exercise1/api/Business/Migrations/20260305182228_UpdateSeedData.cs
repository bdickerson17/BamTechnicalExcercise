using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StargateAPI.Business.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "Gandolf" },
                    { 4, "Cooper Howard" },
                    { 5, "The Wander" },
                    { 6, "Lucy Mcclain" },
                    { 7, "Barbara Howard" },
                    { 8, "Frodo Baggins" },
                    { 9, "Cassian Andor" },
                    { 10, "Jon Snow" },
                    { 11, "Alexander Hamilton" }
                });

            migrationBuilder.InsertData(
                table: "AstronautDuty",
                columns: new[] { "Id", "DutyEndDate", "DutyStartDate", "DutyTitle", "PersonId", "Rank" },
                values: new object[,]
                {
                    { 2, null, new DateTime(2012, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The White", 3, "MAJ" },
                    { 3, null, new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pilot", 4, "CPT" },
                    { 4, null, new DateTime(2020, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Explorer", 5, "LT" },
                    { 5, null, new DateTime(2019, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scientist", 6, "CIV" },
                    { 6, null, new DateTime(2018, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Engineer", 7, "CIV" },
                    { 7, new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ringbearer", 8, "ENS" },
                    { 8, null, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Operative", 9, "CPT" },
                    { 9, null, new DateTime(2019, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lord Commander", 10, "CPT" },
                    { 10, null, new DateTime(1789, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Treasurer", 11, "MAJ" },
                    { 11, new DateTime(2012, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2011, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Grey", 3, "MAJ" },
                    { 12, new DateTime(2019, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RETIRED", 10, "CPT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AstronautDuty",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AstronautDuty",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AstronautDuty",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AstronautDuty",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AstronautDuty",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AstronautDuty",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AstronautDuty",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AstronautDuty",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AstronautDuty",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AstronautDuty",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AstronautDuty",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 11);
        }
    }
}
