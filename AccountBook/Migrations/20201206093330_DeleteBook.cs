using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountBook.Migrations
{
    public partial class DeleteBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_paymentDetails_categoryMasters_CategoryId",
                table: "paymentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_paymentDetails_paymentTypeMasters_PaymentTypeId",
                table: "paymentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_paymentDetails_taxMasters_TaxTypeId",
                table: "paymentDetails");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "taxMasters",
                newName: "TaxMasterId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "paymentTypeMasters",
                newName: "PaymentTypeMasterId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "paymentHeaders",
                newName: "PaymentHeaderId");

            migrationBuilder.RenameColumn(
                name: "TaxTypeId",
                table: "paymentDetails",
                newName: "TaxTypeTaxMasterId");

            migrationBuilder.RenameColumn(
                name: "PaymentTypeId",
                table: "paymentDetails",
                newName: "PaymentTypeMasterId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "paymentDetails",
                newName: "CategoryMasterId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "paymentDetails",
                newName: "PaymentDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_paymentDetails_TaxTypeId",
                table: "paymentDetails",
                newName: "IX_paymentDetails_TaxTypeTaxMasterId");

            migrationBuilder.RenameIndex(
                name: "IX_paymentDetails_PaymentTypeId",
                table: "paymentDetails",
                newName: "IX_paymentDetails_PaymentTypeMasterId");

            migrationBuilder.RenameIndex(
                name: "IX_paymentDetails_CategoryId",
                table: "paymentDetails",
                newName: "IX_paymentDetails_CategoryMasterId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "categoryMasters",
                newName: "CategoryMasterId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "attachmentFiles",
                newName: "AttachmentFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_paymentDetails_categoryMasters_CategoryMasterId",
                table: "paymentDetails",
                column: "CategoryMasterId",
                principalTable: "categoryMasters",
                principalColumn: "CategoryMasterId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_paymentDetails_paymentTypeMasters_PaymentTypeMasterId",
                table: "paymentDetails",
                column: "PaymentTypeMasterId",
                principalTable: "paymentTypeMasters",
                principalColumn: "PaymentTypeMasterId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_paymentDetails_taxMasters_TaxTypeTaxMasterId",
                table: "paymentDetails",
                column: "TaxTypeTaxMasterId",
                principalTable: "taxMasters",
                principalColumn: "TaxMasterId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_paymentDetails_categoryMasters_CategoryMasterId",
                table: "paymentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_paymentDetails_paymentTypeMasters_PaymentTypeMasterId",
                table: "paymentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_paymentDetails_taxMasters_TaxTypeTaxMasterId",
                table: "paymentDetails");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TaxMasterId",
                table: "taxMasters",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PaymentTypeMasterId",
                table: "paymentTypeMasters",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PaymentHeaderId",
                table: "paymentHeaders",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TaxTypeTaxMasterId",
                table: "paymentDetails",
                newName: "TaxTypeId");

            migrationBuilder.RenameColumn(
                name: "PaymentTypeMasterId",
                table: "paymentDetails",
                newName: "PaymentTypeId");

            migrationBuilder.RenameColumn(
                name: "CategoryMasterId",
                table: "paymentDetails",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "PaymentDetailId",
                table: "paymentDetails",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_paymentDetails_TaxTypeTaxMasterId",
                table: "paymentDetails",
                newName: "IX_paymentDetails_TaxTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_paymentDetails_PaymentTypeMasterId",
                table: "paymentDetails",
                newName: "IX_paymentDetails_PaymentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_paymentDetails_CategoryMasterId",
                table: "paymentDetails",
                newName: "IX_paymentDetails_CategoryId");

            migrationBuilder.RenameColumn(
                name: "CategoryMasterId",
                table: "categoryMasters",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AttachmentFileId",
                table: "attachmentFiles",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Sample = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_paymentDetails_categoryMasters_CategoryId",
                table: "paymentDetails",
                column: "CategoryId",
                principalTable: "categoryMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_paymentDetails_paymentTypeMasters_PaymentTypeId",
                table: "paymentDetails",
                column: "PaymentTypeId",
                principalTable: "paymentTypeMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_paymentDetails_taxMasters_TaxTypeId",
                table: "paymentDetails",
                column: "TaxTypeId",
                principalTable: "taxMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
