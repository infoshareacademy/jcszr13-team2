using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelHero.Database.Migrations
{
    /// <inheritdoc />
    public partial class Payment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Payment",
                newName: "CustomerDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_CustomerDataId",
                table: "Payment",
                column: "CustomerDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_CustomerDatas_CustomerDataId",
                table: "Payment",
                column: "CustomerDataId",
                principalTable: "CustomerDatas",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_CustomerDatas_CustomerDataId",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_CustomerDataId",
                table: "Payment");

            migrationBuilder.RenameColumn(
                name: "CustomerDataId",
                table: "Payment",
                newName: "UserId");
        }
    }
}
