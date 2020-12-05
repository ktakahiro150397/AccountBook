using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountBook.Migrations
{
    public partial class FixRelation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "paymentDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_paymentDetails_CategoryId",
                table: "paymentDetails",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_paymentDetails_categoryMasters_CategoryId",
                table: "paymentDetails",
                column: "CategoryId",
                principalTable: "categoryMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_paymentDetails_categoryMasters_CategoryId",
                table: "paymentDetails");

            migrationBuilder.DropIndex(
                name: "IX_paymentDetails_CategoryId",
                table: "paymentDetails");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "paymentDetails");
        }
    }
}
