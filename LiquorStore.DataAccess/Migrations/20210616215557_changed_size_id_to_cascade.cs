using Microsoft.EntityFrameworkCore.Migrations;

namespace LiquorStore.DataAccess.Migrations
{
    public partial class changed_size_id_to_cascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LiquorSizes_Sizes_SizeId",
                table: "LiquorSizes");

            migrationBuilder.AddForeignKey(
                name: "FK_LiquorSizes_Sizes_SizeId",
                table: "LiquorSizes",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LiquorSizes_Sizes_SizeId",
                table: "LiquorSizes");

            migrationBuilder.AddForeignKey(
                name: "FK_LiquorSizes_Sizes_SizeId",
                table: "LiquorSizes",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
