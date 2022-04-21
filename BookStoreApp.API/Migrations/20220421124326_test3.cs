using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreApp.API.Migrations
{
    public partial class test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8343074e-8623-4e1a-b0c1-84fb8678c8f3",
                column: "ConcurrencyStamp",
                value: "36d3112c-a10d-4e7b-ac10-aac4e8b5f59a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7ac6cfe-1f10-4baf-b604-cde350db9554",
                column: "ConcurrencyStamp",
                value: "8632e8f6-4924-46c9-8ce0-b9fb5d40e159");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30a24107-d279-4e37-96fd-01af5b38cb27",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d1250ca0-02ff-4ea5-8f9c-9a6340a06a4f", "AQAAAAEAACcQAAAAEFTe34q+Lzz8gQiXdxZlglUEO1apdfO/IegsX94HuUtTqeCyoKtFdLU9SdobKM2BsQ==", "15043152-5c34-4fa5-9c7e-58099e8d61e6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e448afa-f008-446e-a52f-13c449803c2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "952b3e38-2314-4145-85d1-deed864f6f10", "AQAAAAEAACcQAAAAEOGmRI9v7BmncFNqvTlzxAub3N5WfWYnloj8fTph6kESShFyGyX8TRUTpCUwaodyog==", "ca185cd4-fcb0-42e1-a034-6fd93fdc39f5" });
        }
    }
}
