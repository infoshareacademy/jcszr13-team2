using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelHero.Database.Migrations
{
    /// <inheritdoc />
    public partial class CusomerData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerDataId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AdditionalService",
                columns: table => new
                {
                    AdditionalServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsSelected = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalService", x => x.AdditionalServiceId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDatas",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Favourites = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rodo = table.Column<bool>(type: "bit", nullable: false),
                    Newsletter = table.Column<bool>(type: "bit", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDatas", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stars = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    IsFreeWiFi = table.Column<bool>(type: "bit", nullable: false),
                    IsPrivateParking = table.Column<bool>(type: "bit", nullable: false),
                    IsRestaurant = table.Column<bool>(type: "bit", nullable: false),
                    IsBar = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AmountOfPeople = table.Column<int>(type: "int", nullable: false),
                    CostPerNight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ReservationUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerDataCustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservation_CustomerDatas_CustomerDataCustomerId",
                        column: x => x.CustomerDataCustomerId,
                        principalTable: "CustomerDatas",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_Reservation_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payment_Reservation_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentAdditionalService",
                columns: table => new
                {
                    PaymentAdditionalServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentId = table.Column<int>(type: "int", nullable: false),
                    AdditionalServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentAdditionalService", x => x.PaymentAdditionalServiceId);
                    table.ForeignKey(
                        name: "FK_PaymentAdditionalService_AdditionalService_AdditionalServiceId",
                        column: x => x.AdditionalServiceId,
                        principalTable: "AdditionalService",
                        principalColumn: "AdditionalServiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentAdditionalService_Payment_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payment",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CustomerDataId",
                table: "AspNetUsers",
                column: "CustomerDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_ReservationId",
                table: "Payment",
                column: "ReservationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentAdditionalService_AdditionalServiceId",
                table: "PaymentAdditionalService",
                column: "AdditionalServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentAdditionalService_PaymentId",
                table: "PaymentAdditionalService",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_CustomerDataCustomerId",
                table: "Reservation",
                column: "CustomerDataCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_HotelId",
                table: "Reservation",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_CustomerDatas_CustomerDataId",
                table: "AspNetUsers",
                column: "CustomerDataId",
                principalTable: "CustomerDatas",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_CustomerDatas_CustomerDataId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "PaymentAdditionalService");

            migrationBuilder.DropTable(
                name: "AdditionalService");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "CustomerDatas");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CustomerDataId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CustomerDataId",
                table: "AspNetUsers");
        }
    }
}
