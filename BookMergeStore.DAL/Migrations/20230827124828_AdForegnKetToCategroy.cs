using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookMergeStore.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AdForegnKetToCategroy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CateforyId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CateforyId", "CategoryId" },
                values: new object[] { null, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CateforyId", "CategoryId" },
                values: new object[] { null, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CateforyId", "CategoryId" },
                values: new object[] { null, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CateforyId", "CategoryId" },
                values: new object[] { null, 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CateforyId", "CategoryId" },
                values: new object[] { null, 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CateforyId", "CategoryId" },
                values: new object[] { null, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CateforyId",
                table: "Products",
                column: "CateforyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CateforyId",
                table: "Products",
                column: "CateforyId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CateforyId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CateforyId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CateforyId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");
        }
    }
}
