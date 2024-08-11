using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelHero.Database.Migrations
{
    /// <inheritdoc />
    public partial class Reservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_CustomerDatas_CustomerDataCustomerId",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_CustomerDataCustomerId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "CustomerDataCustomerId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "ReservationUser",
                table: "Reservation");

            migrationBuilder.AddColumn<int>(
                name: "CustomerDataId",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_CustomerDataId",
                table: "Reservation",
                column: "CustomerDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_CustomerDatas_CustomerDataId",
                table: "Reservation",
                column: "CustomerDataId",
                principalTable: "CustomerDatas",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_CustomerDatas_CustomerDataId",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_CustomerDataId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "CustomerDataId",
                table: "Reservation");

            migrationBuilder.AddColumn<int>(
                name: "CustomerDataCustomerId",
                table: "Reservation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReservationUser",
                table: "Reservation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_CustomerDataCustomerId",
                table: "Reservation",
                column: "CustomerDataCustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_CustomerDatas_CustomerDataCustomerId",
                table: "Reservation",
                column: "CustomerDataCustomerId",
                principalTable: "CustomerDatas",
                principalColumn: "CustomerId");
        }
    }
}
