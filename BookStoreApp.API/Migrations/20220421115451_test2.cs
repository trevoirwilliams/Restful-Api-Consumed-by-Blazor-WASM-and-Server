using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreApp.API.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8343074e-8623-4e1a-b0c1-84fb8678c8f3",
                column: "ConcurrencyStamp",
                value: "836503e3-3209-4b13-9f84-a7e952913117");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7ac6cfe-1f10-4baf-b604-cde350db9554",
                column: "ConcurrencyStamp",
                value: "2264222a-383c-4b36-803b-39d5ad103a40");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30a24107-d279-4e37-96fd-01af5b38cb27",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f910a1a0-fe03-4ed0-a5ef-4738ef0c2c18", "AQAAAAEAACcQAAAAEMvcRlEaQRkfekcPMHYtlx0ipa6xhEd0E3IfYsXuGtPCih/trY6GI297XCw8oJWX7A==", "2a67cb25-32ca-4b99-864e-7095e016a3e3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e448afa-f008-446e-a52f-13c449803c2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3b9123f-ffc3-486c-8d93-532a2903ebf5", "AQAAAAEAACcQAAAAEK9imbr4pkjr/dHOTBSkT21dwv3pNePrJaoA6rBO7qc132R2mY39mUml2OUXcKmiWQ==", "f72a2c0e-3306-4f6d-84f6-094bce7eb9e7" });
        }
    }
}
