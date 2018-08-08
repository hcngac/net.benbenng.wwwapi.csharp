using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace net.benbenng.wwwapi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Finished = table.Column<bool>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "Contents",
                columns: table => new
                {
                    ContentId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    LastEditedTime = table.Column<DateTime>(nullable: false),
                    ShownInBlogs = table.Column<bool>(nullable: false),
                    ProjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contents", x => x.ContentId);
                    table.ForeignKey(
                        name: "FK_Contents_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    ContentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagId);
                    table.ForeignKey(
                        name: "FK_Tags_Contents_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Contents",
                        principalColumn: "ContentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Taggings",
                columns: table => new
                {
                    TaggingId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TagId = table.Column<int>(nullable: true),
                    ContentId = table.Column<int>(nullable: true),
                    ProjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taggings", x => x.TaggingId);
                    table.ForeignKey(
                        name: "FK_Taggings_Contents_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Contents",
                        principalColumn: "ContentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Taggings_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Taggings_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Contents",
                columns: new[] { "ContentId", "CreatedTime", "LastEditedTime", "ProjectId", "ShownInBlogs", "Text", "Title" },
                values: new object[] { 1, new DateTime(2018, 8, 7, 13, 25, 7, 937, DateTimeKind.Local), new DateTime(2018, 8, 7, 13, 25, 7, 938, DateTimeKind.Local), null, true, "Hello World!", "First Content" });

            migrationBuilder.InsertData(
                table: "Contents",
                columns: new[] { "ContentId", "CreatedTime", "LastEditedTime", "ProjectId", "ShownInBlogs", "Text", "Title" },
                values: new object[] { 2, new DateTime(2018, 8, 7, 13, 25, 7, 938, DateTimeKind.Local), new DateTime(2018, 8, 7, 13, 25, 7, 938, DateTimeKind.Local), null, true, "Hello World!", "First Content" });

            migrationBuilder.InsertData(
                table: "Contents",
                columns: new[] { "ContentId", "CreatedTime", "LastEditedTime", "ProjectId", "ShownInBlogs", "Text", "Title" },
                values: new object[] { 3, new DateTime(2018, 8, 7, 13, 25, 7, 938, DateTimeKind.Local), new DateTime(2018, 8, 7, 13, 25, 7, 938, DateTimeKind.Local), null, true, "Hello World!", "First Content" });

            migrationBuilder.CreateIndex(
                name: "IX_Contents_ProjectId",
                table: "Contents",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Taggings_ContentId",
                table: "Taggings",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Taggings_ProjectId",
                table: "Taggings",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Taggings_TagId",
                table: "Taggings",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ContentId",
                table: "Tags",
                column: "ContentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Taggings");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Contents");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
