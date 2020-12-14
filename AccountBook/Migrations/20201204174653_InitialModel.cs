using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountBook.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Publisher",
                table: "Book",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "taxMasters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxRate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taxMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "paymentHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMonth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActuialPaymentMonth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Memo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoneyAmount = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paymentHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_paymentHeaders_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "attachmentFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Seq = table.Column<int>(type: "int", nullable: false),
                    AttachFile = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    AttachFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttachFileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentHeaderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attachmentFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_attachmentFiles_paymentHeaders_PaymentHeaderId",
                        column: x => x.PaymentHeaderId,
                        principalTable: "paymentHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "paymentTypeMasters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
                    IsCategoryChangable = table.Column<bool>(type: "bit", nullable: false),
                    DefaultCategoryId = table.Column<int>(type: "int", nullable: true),
                    Group = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paymentTypeMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "categoryMasters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentTypeMasterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoryMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_categoryMasters_paymentTypeMasters_PaymentTypeMasterId",
                        column: x => x.PaymentTypeMasterId,
                        principalTable: "paymentTypeMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "paymentDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentTypeId = table.Column<int>(type: "int", nullable: true),
                    MoneyAmount = table.Column<long>(type: "bigint", nullable: false),
                    UnitPrice = table.Column<long>(type: "bigint", nullable: false),
                    UnitCount = table.Column<int>(type: "int", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Memo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxTypeId = table.Column<int>(type: "int", nullable: true),
                    PaymentHeaderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paymentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_paymentDetails_paymentHeaders_PaymentHeaderId",
                        column: x => x.PaymentHeaderId,
                        principalTable: "paymentHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_paymentDetails_paymentTypeMasters_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "paymentTypeMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_paymentDetails_taxMasters_TaxTypeId",
                        column: x => x.TaxTypeId,
                        principalTable: "taxMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_attachmentFiles_PaymentHeaderId",
                table: "attachmentFiles",
                column: "PaymentHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_categoryMasters_PaymentTypeMasterId",
                table: "categoryMasters",
                column: "PaymentTypeMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_paymentDetails_PaymentHeaderId",
                table: "paymentDetails",
                column: "PaymentHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_paymentDetails_PaymentTypeId",
                table: "paymentDetails",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_paymentDetails_TaxTypeId",
                table: "paymentDetails",
                column: "TaxTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_paymentHeaders_UserId",
                table: "paymentHeaders",
                column: "UserId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categoryMasters_paymentTypeMasters_PaymentTypeMasterId",
                table: "categoryMasters");

            migrationBuilder.DropTable(
                name: "attachmentFiles");

            migrationBuilder.DropTable(
                name: "paymentDetails");

            migrationBuilder.DropTable(
                name: "paymentHeaders");

            migrationBuilder.DropTable(
                name: "taxMasters");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "paymentTypeMasters");

            migrationBuilder.DropTable(
                name: "categoryMasters");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Book",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Publisher",
                table: "Book",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);
        }
    }
}
