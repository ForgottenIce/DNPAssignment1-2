using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfcDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CommentTitleCanNowBeNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubPages_Users_OwnerId",
                table: "SubPages");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "SubPages",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "UserSubscribedToSub",
                columns: table => new
                {
                    SubscribedSubsId = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSubscribedToSub", x => new { x.SubscribedSubsId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserSubscribedToSub_SubPages_SubscribedSubsId",
                        column: x => x.SubscribedSubsId,
                        principalTable: "SubPages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSubscribedToSub_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSubscribedToSub_UserId",
                table: "UserSubscribedToSub",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubPages_Users_OwnerId",
                table: "SubPages",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubPages_Users_OwnerId",
                table: "SubPages");

            migrationBuilder.DropTable(
                name: "UserSubscribedToSub");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "SubPages",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SubPages_Users_OwnerId",
                table: "SubPages",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
