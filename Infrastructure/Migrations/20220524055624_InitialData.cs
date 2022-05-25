using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PostTags",
                table: "PostTags");

            migrationBuilder.DropIndex(
                name: "IX_PostTags_PostId",
                table: "PostTags");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostTags",
                table: "PostTags",
                columns: new[] { "PostId", "TagId" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Author", "Title" },
                values: new object[] { new Guid("9ae8d2e9-c241-4abc-9d20-d6c6c2ad3540"), "Joseph Maina", "Category Three" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Author", "Title" },
                values: new object[] { new Guid("c5f8634a-fa78-424d-85b9-4066113eb2bb"), "Joseph Maina", "Category Two" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Author", "Title" },
                values: new object[] { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Joseph Maina", "Category One" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PostTags",
                table: "PostTags");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("9ae8d2e9-c241-4abc-9d20-d6c6c2ad3540"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("c5f8634a-fa78-424d-85b9-4066113eb2bb"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostTags",
                table: "PostTags",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_PostId",
                table: "PostTags",
                column: "PostId");
        }
    }
}
