using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SB.EntityFramework.Migrations
{
    public partial class Added_Table_Category_And_Item : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_ID_FK = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    ItemCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Items_Categories_Category_ID_FK",
                        column: x => x.Category_ID_FK,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedOn", "IsDeleted", "Name", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 6, 13, 18, 47, 33, 276, DateTimeKind.Local).AddTicks(1149), false, "Tables", new DateTime(2022, 6, 13, 18, 47, 33, 278, DateTimeKind.Local).AddTicks(1881) },
                    { 2, new DateTime(2022, 6, 13, 18, 47, 33, 278, DateTimeKind.Local).AddTicks(4116), false, "Chairs", new DateTime(2022, 6, 13, 18, 47, 33, 278, DateTimeKind.Local).AddTicks(4137) },
                    { 3, new DateTime(2022, 6, 13, 18, 47, 33, 278, DateTimeKind.Local).AddTicks(4142), false, "Wardroabs", new DateTime(2022, 6, 13, 18, 47, 33, 278, DateTimeKind.Local).AddTicks(4144) },
                    { 4, new DateTime(2022, 6, 13, 18, 47, 33, 278, DateTimeKind.Local).AddTicks(4147), false, "Beds", new DateTime(2022, 6, 13, 18, 47, 33, 278, DateTimeKind.Local).AddTicks(4149) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_Category_ID_FK",
                table: "Items",
                column: "Category_ID_FK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
