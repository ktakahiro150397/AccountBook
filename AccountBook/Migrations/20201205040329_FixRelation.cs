using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountBook.Migrations
{
    public partial class FixRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_paymentTypeMasters_categoryMasters_DefaultCategoryId",
                table: "paymentTypeMasters");

            migrationBuilder.DropIndex(
                name: "IX_paymentTypeMasters_DefaultCategoryId",
                table: "paymentTypeMasters");

            migrationBuilder.DropColumn(
                name: "DefaultCategoryId",
                table: "paymentTypeMasters");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DefaultCategoryId",
                table: "paymentTypeMasters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_paymentTypeMasters_DefaultCategoryId",
                table: "paymentTypeMasters",
                column: "DefaultCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_paymentTypeMasters_categoryMasters_DefaultCategoryId",
                table: "paymentTypeMasters",
                column: "DefaultCategoryId",
                principalTable: "categoryMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
