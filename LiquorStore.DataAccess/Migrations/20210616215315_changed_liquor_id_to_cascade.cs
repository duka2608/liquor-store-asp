using Microsoft.EntityFrameworkCore.Migrations;

namespace LiquorStore.DataAccess.Migrations
{
    public partial class changed_liquor_id_to_cascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LiquorSizes_Liquors_LiquorId",
                table: "LiquorSizes");

            migrationBuilder.AddForeignKey(
                name: "FK_LiquorSizes_Liquors_LiquorId",
                table: "LiquorSizes",
                column: "LiquorId",
                principalTable: "Liquors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LiquorSizes_Liquors_LiquorId",
                table: "LiquorSizes");

            migrationBuilder.AddForeignKey(
                name: "FK_LiquorSizes_Liquors_LiquorId",
                table: "LiquorSizes",
                column: "LiquorId",
                principalTable: "Liquors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
