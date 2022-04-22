using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreApp.API.Migrations
{
    public partial class test4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8343074e-8623-4e1a-b0c1-84fb8678c8f3",
                column: "ConcurrencyStamp",
                value: "65410d4f-7ee0-47d0-8711-77b442e13ba9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7ac6cfe-1f10-4baf-b604-cde350db9554",
                column: "ConcurrencyStamp",
                value: "edf34e02-9877-4d98-92b5-704ddeb9f295");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30a24107-d279-4e37-96fd-01af5b38cb27",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9fd511f-9698-4326-8bcd-09e7fbcd98a3", "AQAAAAEAACcQAAAAEKM1fgrNkiaq1scYzsOiQmCTdaG5x/2SLi9qUhLRGiq40lvWsW1We09QOAxGfWX+Nw==", "d88b5148-528f-437d-9d38-72c567a8a034" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e448afa-f008-446e-a52f-13c449803c2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e84ed6a-fa65-4cc2-8bdf-516630c90079", "AQAAAAEAACcQAAAAEHY0A86BvDta68EDH1VhfkXcBedxHSHzzPNk7L6as+FrGpGNgl1OOlpoLMsZYwZ9+Q==", "adfaa9ff-36b2-4354-9d60-0922238d7d06" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8343074e-8623-4e1a-b0c1-84fb8678c8f3",
                column: "ConcurrencyStamp",
                value: "a47ded34-07ff-4bad-94f2-acf2a1c8417b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7ac6cfe-1f10-4baf-b604-cde350db9554",
                column: "ConcurrencyStamp",
                value: "8a2bd66a-c94b-4dd0-b436-8a4a2418f7e2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30a24107-d279-4e37-96fd-01af5b38cb27",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "11ea0164-0fce-4031-b3b8-22bb81642632", "AQAAAAEAACcQAAAAEFpygwSIOa7Qku5KbGz0YFaD0hFFJT6bDy1VuRwERE+KVjjoVzjtvJRwLywqfOcRJg==", "ddc51fbc-c7e8-4cde-85e2-bf990e227bd5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e448afa-f008-446e-a52f-13c449803c2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f18c1942-d3d1-4fc3-95a7-e84e5d525d57", "AQAAAAEAACcQAAAAEB36yrBfYCCDFhTCvaDqpKW6zDnCRLXH93M92yjxWgVa9b1MPchQimv6pnUdpU2+Nw==", "eb79ffdc-3aec-440d-b75c-029caa828638" });
        }
    }
}
