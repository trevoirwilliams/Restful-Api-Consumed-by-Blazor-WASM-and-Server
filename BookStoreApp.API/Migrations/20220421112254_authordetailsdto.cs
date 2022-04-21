using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreApp.API.Migrations
{
    public partial class authordetailsdto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8343074e-8623-4e1a-b0c1-84fb8678c8f3",
                column: "ConcurrencyStamp",
                value: "f58599ac-0b89-4b90-bec9-3fda85bae0b6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7ac6cfe-1f10-4baf-b604-cde350db9554",
                column: "ConcurrencyStamp",
                value: "60109d00-8b54-47f5-a5a7-9f67d2f6c175");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30a24107-d279-4e37-96fd-01af5b38cb27",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f1fe9ff-d41a-48c5-bc5e-b4986d6adca5", "AQAAAAEAACcQAAAAEJ5288kdys9IMhZXOZCTPbgarrKchGdIEiN+MpjURHWODtSLPmpdiJQH3lea6/F+Zw==", "be0f71da-b7dc-4ec4-a51a-ad900844ae31" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e448afa-f008-446e-a52f-13c449803c2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e894c9ad-afce-4c58-9ac0-651d88c78427", "AQAAAAEAACcQAAAAEBiTT4E5UK7LP3Nl1o2l/2ZtZJL27Gl1q5TKUJN/OpqwwwdFleoN2MFd7DakpggWCw==", "e9244732-3d9f-4e90-9cb7-63b33ea24386" });
        }
    }
}
