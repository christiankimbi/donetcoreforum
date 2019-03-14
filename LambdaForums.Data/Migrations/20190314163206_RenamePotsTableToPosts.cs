using Microsoft.EntityFrameworkCore.Migrations;

namespace LambdaForums.Data.Migrations
{
    public partial class RenamePotsTableToPosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostReplies_Pots_PostId",
                table: "PostReplies");

            migrationBuilder.DropForeignKey(
                name: "FK_Pots_Forums_ForumId",
                table: "Pots");

            migrationBuilder.DropForeignKey(
                name: "FK_Pots_AspNetUsers_UserId",
                table: "Pots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pots",
                table: "Pots");

            migrationBuilder.RenameTable(
                name: "Pots",
                newName: "Posts");

            migrationBuilder.RenameIndex(
                name: "IX_Pots_UserId",
                table: "Posts",
                newName: "IX_Posts_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Pots_ForumId",
                table: "Posts",
                newName: "IX_Posts_ForumId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostReplies_Posts_PostId",
                table: "PostReplies",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Forums_ForumId",
                table: "Posts",
                column: "ForumId",
                principalTable: "Forums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostReplies_Posts_PostId",
                table: "PostReplies");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Forums_ForumId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "Pots");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_UserId",
                table: "Pots",
                newName: "IX_Pots_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_ForumId",
                table: "Pots",
                newName: "IX_Pots_ForumId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pots",
                table: "Pots",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostReplies_Pots_PostId",
                table: "PostReplies",
                column: "PostId",
                principalTable: "Pots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pots_Forums_ForumId",
                table: "Pots",
                column: "ForumId",
                principalTable: "Forums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pots_AspNetUsers_UserId",
                table: "Pots",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
