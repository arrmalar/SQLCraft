using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SQLCraft.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangedQuerryRiddleToQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QueryRiddles");

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DBSchemaID = table.Column<int>(type: "int", nullable: false),
                    QuestionCorrectAnswerID = table.Column<int>(type: "int", nullable: false),
                    QuestionLevelID = table.Column<int>(type: "int", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Questions_DBSchemas_DBSchemaID",
                        column: x => x.DBSchemaID,
                        principalTable: "DBSchemas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questions_QuestionCorrectAnswers_QuestionCorrectAnswerID",
                        column: x => x.QuestionCorrectAnswerID,
                        principalTable: "QuestionCorrectAnswers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questions_QuestionLevels_QuestionLevelID",
                        column: x => x.QuestionLevelID,
                        principalTable: "QuestionLevels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_DBSchemaID",
                table: "Questions",
                column: "DBSchemaID");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuestionCorrectAnswerID",
                table: "Questions",
                column: "QuestionCorrectAnswerID");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuestionLevelID",
                table: "Questions",
                column: "QuestionLevelID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.CreateTable(
                name: "QueryRiddles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DBSchemaID = table.Column<int>(type: "int", nullable: false),
                    QuestionCorrectAnswerID = table.Column<int>(type: "int", nullable: false),
                    QuestionLevelID = table.Column<int>(type: "int", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QueryRiddles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_QueryRiddles_DBSchemas_DBSchemaID",
                        column: x => x.DBSchemaID,
                        principalTable: "DBSchemas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QueryRiddles_QuestionCorrectAnswers_QuestionCorrectAnswerID",
                        column: x => x.QuestionCorrectAnswerID,
                        principalTable: "QuestionCorrectAnswers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QueryRiddles_QuestionLevels_QuestionLevelID",
                        column: x => x.QuestionLevelID,
                        principalTable: "QuestionLevels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QueryRiddles_DBSchemaID",
                table: "QueryRiddles",
                column: "DBSchemaID");

            migrationBuilder.CreateIndex(
                name: "IX_QueryRiddles_QuestionCorrectAnswerID",
                table: "QueryRiddles",
                column: "QuestionCorrectAnswerID");

            migrationBuilder.CreateIndex(
                name: "IX_QueryRiddles_QuestionLevelID",
                table: "QueryRiddles",
                column: "QuestionLevelID");
        }
    }
}
