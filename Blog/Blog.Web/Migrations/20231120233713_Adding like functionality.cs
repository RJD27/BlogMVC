using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Web.Migrations
{
    /// <inheritdoc />
    public partial class Addinglikefunctionality : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostTag_BlogPosts_BlogPostsID",
                table: "BlogPostTag");

            migrationBuilder.RenameColumn(
                name: "BlogPostsID",
                table: "BlogPostTag",
                newName: "BlogPostsId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "BlogPosts",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "BlogPostLike",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlogPostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPostLike", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPostLike_BlogPosts_BlogPostId",
                        column: x => x.BlogPostId,
                        principalTable: "BlogPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostLike_BlogPostId",
                table: "BlogPostLike",
                column: "BlogPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostTag_BlogPosts_BlogPostsId",
                table: "BlogPostTag",
                column: "BlogPostsId",
                principalTable: "BlogPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostTag_BlogPosts_BlogPostsId",
                table: "BlogPostTag");

            migrationBuilder.DropTable(
                name: "BlogPostLike");

            migrationBuilder.RenameColumn(
                name: "BlogPostsId",
                table: "BlogPostTag",
                newName: "BlogPostsID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BlogPosts",
                newName: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostTag_BlogPosts_BlogPostsID",
                table: "BlogPostTag",
                column: "BlogPostsID",
                principalTable: "BlogPosts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
