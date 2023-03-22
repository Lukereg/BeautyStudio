using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeautyStudio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BeautyStudioAndVisitEdited : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BeauticianId",
                table: "Visits",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "BeautyStudios",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "BeautyStudioId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Visits_BeauticianId",
                table: "Visits",
                column: "BeauticianId");

            migrationBuilder.CreateIndex(
                name: "IX_BeautyStudios_OwnerId",
                table: "BeautyStudios",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BeautyStudioId",
                table: "AspNetUsers",
                column: "BeautyStudioId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_BeautyStudios_BeautyStudioId",
                table: "AspNetUsers",
                column: "BeautyStudioId",
                principalTable: "BeautyStudios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BeautyStudios_AspNetUsers_OwnerId",
                table: "BeautyStudios",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_AspNetUsers_BeauticianId",
                table: "Visits",
                column: "BeauticianId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_BeautyStudios_BeautyStudioId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_BeautyStudios_AspNetUsers_OwnerId",
                table: "BeautyStudios");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_AspNetUsers_BeauticianId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_BeauticianId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_BeautyStudios_OwnerId",
                table: "BeautyStudios");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BeautyStudioId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BeauticianId",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "BeautyStudios");

            migrationBuilder.DropColumn(
                name: "BeautyStudioId",
                table: "AspNetUsers");
        }
    }
}
