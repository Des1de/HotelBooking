using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.Migrations
{
    /// <inheritdoc />
    public partial class ReviewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "HotelRoomReviews");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "HotelReviews");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "HotelRoomReviews",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "HotelReviews",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "HotelRoomReviews");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "HotelReviews");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "HotelRoomReviews",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "HotelReviews",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
