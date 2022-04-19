using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreApp.API.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8343074e-8623-4e1a-b0c1-84fb8678c8f3",
                column: "ConcurrencyStamp",
                value: "be9e500e-1512-4bfa-9b96-512ae78443ec");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7ac6cfe-1f10-4baf-b604-cde350db9554",
                column: "ConcurrencyStamp",
                value: "dd1b58f1-f21e-444d-9355-02cf08305663");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30a24107-d279-4e37-96fd-01af5b38cb27",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d5e704f7-e1ed-4d5e-b342-95b378c11f0f", "AQAAAAEAACcQAAAAEB/ICKAZpSCdCy9UMU+TcJ8q63NXN0Sjt+PryUWJcd6h90QXubzp0RXClfY5TWAPmg==", "03edf2ed-8474-473d-a4fd-63518a727f61" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e448afa-f008-446e-a52f-13c449803c2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa9d96b6-ed10-4cce-9bad-de308e425b55", "AQAAAAEAACcQAAAAEEgAksn/5c+C6nsosG4xheTV7TZnudZph+mHEknGAhTrbqa+9c/DVoWLUERmMAkEXQ==", "9eb4f0f3-71ba-4673-99b7-a884357e2e8a" });
        }
    }
}
