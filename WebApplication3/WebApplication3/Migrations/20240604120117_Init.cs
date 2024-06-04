using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApplication3.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Photo_folder_DATA",
                columns: table => new
                {
                    Photo_folder_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Photo_folder_Desc = table.Column<string>(type: "text", nullable: false),
                    Photo_folder_Name = table.Column<string>(type: "text", nullable: false),
                    Photo_folder_Path = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo_folder_DATA", x => x.Photo_folder_ID);
                });

            migrationBuilder.CreateTable(
                name: "User_DATA",
                columns: table => new
                {
                    User_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    User_Email = table.Column<string>(type: "text", nullable: false),
                    User_Password = table.Column<string>(type: "text", nullable: false),
                    User_URL = table.Column<string>(type: "text", nullable: false),
                    User_NickName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_DATA", x => x.User_ID);
                });

            migrationBuilder.CreateTable(
                name: "Author_DATA",
                columns: table => new
                {
                    Author_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    User_ID = table.Column<long>(type: "bigint", nullable: false),
                    Photo_folder_ID = table.Column<long>(type: "bigint", nullable: false),
                    Author_URL = table.Column<string>(type: "text", nullable: false),
                    Author_Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author_DATA", x => x.Author_ID);
                    table.ForeignKey(
                        name: "FK_Author_DATA_Photo_folder_DATA_Photo_folder_ID",
                        column: x => x.Photo_folder_ID,
                        principalTable: "Photo_folder_DATA",
                        principalColumn: "Photo_folder_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Author_DATA_User_DATA_User_ID",
                        column: x => x.User_ID,
                        principalTable: "User_DATA",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Article_DATA",
                columns: table => new
                {
                    Article_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Author_ID = table.Column<long>(type: "bigint", nullable: false),
                    Article_Name = table.Column<string>(type: "text", nullable: false),
                    Category_Name = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<long>(type: "bigint", nullable: false),
                    Creation_Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Photo_folder_ID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article_DATA", x => x.Article_ID);
                    table.ForeignKey(
                        name: "FK_Article_DATA_Author_DATA_Author_ID",
                        column: x => x.Author_ID,
                        principalTable: "Author_DATA",
                        principalColumn: "Author_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Article_DATA_Photo_folder_DATA_Photo_folder_ID",
                        column: x => x.Photo_folder_ID,
                        principalTable: "Photo_folder_DATA",
                        principalColumn: "Photo_folder_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Thread_DATA",
                columns: table => new
                {
                    Thread_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Thread_Desc = table.Column<string>(type: "text", nullable: false),
                    Thread_Name = table.Column<string>(type: "text", nullable: false),
                    Author_ID = table.Column<long>(type: "bigint", nullable: false),
                    Rating = table.Column<long>(type: "bigint", nullable: false),
                    Thread_URL = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thread_DATA", x => x.Thread_ID);
                    table.ForeignKey(
                        name: "FK_Thread_DATA_Author_DATA_Author_ID",
                        column: x => x.Author_ID,
                        principalTable: "Author_DATA",
                        principalColumn: "Author_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Topic_DATA",
                columns: table => new
                {
                    Topic_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Thread_ID = table.Column<long>(type: "bigint", nullable: false),
                    Topic_Desc = table.Column<string>(type: "text", nullable: false),
                    Topic_Name = table.Column<string>(type: "text", nullable: false),
                    Topic_URL = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic_DATA", x => x.Topic_ID);
                    table.ForeignKey(
                        name: "FK_Topic_DATA_Thread_DATA_Thread_ID",
                        column: x => x.Thread_ID,
                        principalTable: "Thread_DATA",
                        principalColumn: "Thread_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commentary_DATA",
                columns: table => new
                {
                    Commentary_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Topic_ID = table.Column<long>(type: "bigint", nullable: false),
                    Thread_ID = table.Column<long>(type: "bigint", nullable: false),
                    User_ID = table.Column<long>(type: "bigint", nullable: false),
                    Creation_Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Commentary_size = table.Column<string>(type: "text", nullable: false),
                    Article_ID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentary_DATA", x => x.Commentary_ID);
                    table.ForeignKey(
                        name: "FK_Commentary_DATA_Article_DATA_Article_ID",
                        column: x => x.Article_ID,
                        principalTable: "Article_DATA",
                        principalColumn: "Article_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commentary_DATA_Thread_DATA_Thread_ID",
                        column: x => x.Thread_ID,
                        principalTable: "Thread_DATA",
                        principalColumn: "Thread_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commentary_DATA_Topic_DATA_Topic_ID",
                        column: x => x.Topic_ID,
                        principalTable: "Topic_DATA",
                        principalColumn: "Topic_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commentary_DATA_User_DATA_User_ID",
                        column: x => x.User_ID,
                        principalTable: "User_DATA",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "File_Archive_DATA",
                columns: table => new
                {
                    File_Archive_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Topic_ID = table.Column<long>(type: "bigint", nullable: false),
                    Thread_ID = table.Column<long>(type: "bigint", nullable: false),
                    Commentary_ID = table.Column<long>(type: "bigint", nullable: false),
                    Files_Archive_Desc = table.Column<string>(type: "text", nullable: false),
                    File_Path = table.Column<string>(type: "text", nullable: false),
                    Article_ID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_Archive_DATA", x => x.File_Archive_ID);
                    table.ForeignKey(
                        name: "FK_File_Archive_DATA_Article_DATA_Article_ID",
                        column: x => x.Article_ID,
                        principalTable: "Article_DATA",
                        principalColumn: "Article_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_File_Archive_DATA_Commentary_DATA_Commentary_ID",
                        column: x => x.Commentary_ID,
                        principalTable: "Commentary_DATA",
                        principalColumn: "Commentary_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_File_Archive_DATA_Thread_DATA_Thread_ID",
                        column: x => x.Thread_ID,
                        principalTable: "Thread_DATA",
                        principalColumn: "Thread_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_File_Archive_DATA_Topic_DATA_Topic_ID",
                        column: x => x.Topic_ID,
                        principalTable: "Topic_DATA",
                        principalColumn: "Topic_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_DATA_Author_ID",
                table: "Article_DATA",
                column: "Author_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Article_DATA_Photo_folder_ID",
                table: "Article_DATA",
                column: "Photo_folder_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Author_DATA_Photo_folder_ID",
                table: "Author_DATA",
                column: "Photo_folder_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Author_DATA_User_ID",
                table: "Author_DATA",
                column: "User_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Commentary_DATA_Article_ID",
                table: "Commentary_DATA",
                column: "Article_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Commentary_DATA_Thread_ID",
                table: "Commentary_DATA",
                column: "Thread_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Commentary_DATA_Topic_ID",
                table: "Commentary_DATA",
                column: "Topic_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Commentary_DATA_User_ID",
                table: "Commentary_DATA",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_File_Archive_DATA_Article_ID",
                table: "File_Archive_DATA",
                column: "Article_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_File_Archive_DATA_Commentary_ID",
                table: "File_Archive_DATA",
                column: "Commentary_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_File_Archive_DATA_Thread_ID",
                table: "File_Archive_DATA",
                column: "Thread_ID");

            migrationBuilder.CreateIndex(
                name: "IX_File_Archive_DATA_Topic_ID",
                table: "File_Archive_DATA",
                column: "Topic_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Thread_DATA_Author_ID",
                table: "Thread_DATA",
                column: "Author_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_DATA_Thread_ID",
                table: "Topic_DATA",
                column: "Thread_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "File_Archive_DATA");

            migrationBuilder.DropTable(
                name: "Commentary_DATA");

            migrationBuilder.DropTable(
                name: "Article_DATA");

            migrationBuilder.DropTable(
                name: "Topic_DATA");

            migrationBuilder.DropTable(
                name: "Thread_DATA");

            migrationBuilder.DropTable(
                name: "Author_DATA");

            migrationBuilder.DropTable(
                name: "Photo_folder_DATA");

            migrationBuilder.DropTable(
                name: "User_DATA");
        }
    }
}
