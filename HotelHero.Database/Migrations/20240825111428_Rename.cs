using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelHero.Database.Migrations
{
    /// <inheritdoc />
    public partial class Rename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerDataHotel");

            migrationBuilder.DropTable(
                name: "PaymentAdditionalService");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "AdditionalService");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.CreateTable(
                name: "AdditionalServiceDTO",
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
                    table.PrimaryKey("PK_AdditionalServiceDTO", x => x.AdditionalServiceId);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
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
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentDTO",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerDataId = table.Column<int>(type: "int", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDTO", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_PaymentDTO_CustomerDatas_CustomerDataId",
                        column: x => x.CustomerDataId,
                        principalTable: "CustomerDatas",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDataHotelDTO",
                columns: table => new
                {
                    CustomerDataHotelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerDataId = table.Column<int>(type: "int", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDataHotelDTO", x => x.CustomerDataHotelId);
                    table.ForeignKey(
                        name: "FK_CustomerDataHotelDTO_CustomerDatas_CustomerDataId",
                        column: x => x.CustomerDataId,
                        principalTable: "CustomerDatas",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerDataHotelDTO_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentAdditionalServiceDTO",
                columns: table => new
                {
                    PaymentAdditionalServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentId = table.Column<int>(type: "int", nullable: false),
                    AdditionalServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentAdditionalServiceDTO", x => x.PaymentAdditionalServiceId);
                    table.ForeignKey(
                        name: "FK_PaymentAdditionalServiceDTO_AdditionalServiceDTO_AdditionalServiceId",
                        column: x => x.AdditionalServiceId,
                        principalTable: "AdditionalServiceDTO",
                        principalColumn: "AdditionalServiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentAdditionalServiceDTO_PaymentDTO_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "PaymentDTO",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservationDTO",
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
                    CustomerDataId = table.Column<int>(type: "int", nullable: false),
                    PaymentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationDTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationDTO_CustomerDatas_CustomerDataId",
                        column: x => x.CustomerDataId,
                        principalTable: "CustomerDatas",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationDTO_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationDTO_PaymentDTO_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "PaymentDTO",
                        principalColumn: "PaymentId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDataHotelDTO_CustomerDataId",
                table: "CustomerDataHotelDTO",
                column: "CustomerDataId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDataHotelDTO_HotelId",
                table: "CustomerDataHotelDTO",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentAdditionalServiceDTO_AdditionalServiceId",
                table: "PaymentAdditionalServiceDTO",
                column: "AdditionalServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentAdditionalServiceDTO_PaymentId",
                table: "PaymentAdditionalServiceDTO",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDTO_CustomerDataId",
                table: "PaymentDTO",
                column: "CustomerDataId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationDTO_CustomerDataId",
                table: "ReservationDTO",
                column: "CustomerDataId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationDTO_HotelId",
                table: "ReservationDTO",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationDTO_PaymentId",
                table: "ReservationDTO",
                column: "PaymentId",
                unique: true,
                filter: "[PaymentId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerDataHotelDTO");

            migrationBuilder.DropTable(
                name: "PaymentAdditionalServiceDTO");

            migrationBuilder.DropTable(
                name: "ReservationDTO");

            migrationBuilder.DropTable(
                name: "AdditionalServiceDTO");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "PaymentDTO");

            migrationBuilder.CreateTable(
                name: "AdditionalService",
                columns: table => new
                {
                    AdditionalServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsSelected = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalService", x => x.AdditionalServiceId);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsBar = table.Column<bool>(type: "bit", nullable: false),
                    IsFreeWiFi = table.Column<bool>(type: "bit", nullable: false),
                    IsPrivateParking = table.Column<bool>(type: "bit", nullable: false),
                    IsRestaurant = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    Stars = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerDataId = table.Column<int>(type: "int", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payment_CustomerDatas_CustomerDataId",
                        column: x => x.CustomerDataId,
                        principalTable: "CustomerDatas",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDataHotel",
                columns: table => new
                {
                    CustomerDataHotelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerDataId = table.Column<int>(type: "int", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDataHotel", x => x.CustomerDataHotelId);
                    table.ForeignKey(
                        name: "FK_CustomerDataHotel_CustomerDatas_CustomerDataId",
                        column: x => x.CustomerDataId,
                        principalTable: "CustomerDatas",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerDataHotel_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentAdditionalService",
                columns: table => new
                {
                    PaymentAdditionalServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdditionalServiceId = table.Column<int>(type: "int", nullable: false),
                    PaymentId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerDataId = table.Column<int>(type: "int", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    PaymentId = table.Column<int>(type: "int", nullable: true),
                    AmountOfPeople = table.Column<int>(type: "int", nullable: false),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CostPerNight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservation_CustomerDatas_CustomerDataId",
                        column: x => x.CustomerDataId,
                        principalTable: "CustomerDatas",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Payment_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payment",
                        principalColumn: "PaymentId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDataHotel_CustomerDataId",
                table: "CustomerDataHotel",
                column: "CustomerDataId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDataHotel_HotelId",
                table: "CustomerDataHotel",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_CustomerDataId",
                table: "Payment",
                column: "CustomerDataId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentAdditionalService_AdditionalServiceId",
                table: "PaymentAdditionalService",
                column: "AdditionalServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentAdditionalService_PaymentId",
                table: "PaymentAdditionalService",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_CustomerDataId",
                table: "Reservation",
                column: "CustomerDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_HotelId",
                table: "Reservation",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_PaymentId",
                table: "Reservation",
                column: "PaymentId",
                unique: true,
                filter: "[PaymentId] IS NOT NULL");
        }
    }
}
