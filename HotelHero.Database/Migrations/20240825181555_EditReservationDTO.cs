using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelHero.Database.Migrations
{
    /// <inheritdoc />
    public partial class EditReservationDTO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationDTO_CustomerDatas_CustomerDataId",
                table: "ReservationDTO");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationDTO_Hotels_HotelId",
                table: "ReservationDTO");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationDTO_PaymentDTO_PaymentId",
                table: "ReservationDTO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservationDTO",
                table: "ReservationDTO");

            migrationBuilder.RenameTable(
                name: "ReservationDTO",
                newName: "Reservations");

            migrationBuilder.RenameIndex(
                name: "IX_ReservationDTO_PaymentId",
                table: "Reservations",
                newName: "IX_Reservations_PaymentId");

            migrationBuilder.RenameIndex(
                name: "IX_ReservationDTO_HotelId",
                table: "Reservations",
                newName: "IX_Reservations_HotelId");

            migrationBuilder.RenameIndex(
                name: "IX_ReservationDTO_CustomerDataId",
                table: "Reservations",
                newName: "IX_Reservations_CustomerDataId");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerDataId",
                table: "Reservations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_CustomerDatas_CustomerDataId",
                table: "Reservations",
                column: "CustomerDataId",
                principalTable: "CustomerDatas",
                principalColumn: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Hotels_HotelId",
                table: "Reservations",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_PaymentDTO_PaymentId",
                table: "Reservations",
                column: "PaymentId",
                principalTable: "PaymentDTO",
                principalColumn: "PaymentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_CustomerDatas_CustomerDataId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Hotels_HotelId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_PaymentDTO_PaymentId",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "ReservationDTO");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_PaymentId",
                table: "ReservationDTO",
                newName: "IX_ReservationDTO_PaymentId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_HotelId",
                table: "ReservationDTO",
                newName: "IX_ReservationDTO_HotelId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_CustomerDataId",
                table: "ReservationDTO",
                newName: "IX_ReservationDTO_CustomerDataId");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerDataId",
                table: "ReservationDTO",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservationDTO",
                table: "ReservationDTO",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationDTO_CustomerDatas_CustomerDataId",
                table: "ReservationDTO",
                column: "CustomerDataId",
                principalTable: "CustomerDatas",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationDTO_Hotels_HotelId",
                table: "ReservationDTO",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationDTO_PaymentDTO_PaymentId",
                table: "ReservationDTO",
                column: "PaymentId",
                principalTable: "PaymentDTO",
                principalColumn: "PaymentId");
        }
    }
}
