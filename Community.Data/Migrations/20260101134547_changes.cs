using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Community.Data.Migrations
{
    /// <inheritdoc />
    public partial class changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    coursId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.coursId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoursescoursId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.userId);
                    table.ForeignKey(
                        name: "FK_User_Courses_CoursescoursId",
                        column: x => x.CoursescoursId,
                        principalTable: "Courses",
                        principalColumn: "coursId");
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    teacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    coursName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoursesId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.teacherId);
                    table.ForeignKey(
                        name: "FK_Teacher_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "coursId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teacher_User_userId",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "userId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_CoursesId",
                table: "Teacher",
                column: "CoursesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_userId",
                table: "Teacher",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CoursescoursId",
                table: "User",
                column: "CoursescoursId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
