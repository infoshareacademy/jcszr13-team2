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
            migrationBuilder.DropColumn(
                name: "Favourites",
                table: "CustomerDatas");

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

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDataHotel_CustomerDataId",
                table: "CustomerDataHotel",
                column: "CustomerDataId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDataHotel_HotelId",
                table: "CustomerDataHotel",
                column: "HotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerDataHotel");

            migrationBuilder.AddColumn<string>(
                name: "Favourites",
                table: "CustomerDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
