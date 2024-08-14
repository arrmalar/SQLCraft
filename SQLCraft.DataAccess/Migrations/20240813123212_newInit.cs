using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SQLCraft.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class newInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Column_Table_ColumnId",
                table: "Column");

            migrationBuilder.DropForeignKey(
                name: "FK_Table_DBSchema_TableId",
                table: "Table");

            migrationBuilder.DropIndex(
                name: "IX_Table_TableId",
                table: "Table");

            migrationBuilder.DropIndex(
                name: "IX_Column_ColumnId",
                table: "Column");

            migrationBuilder.DropColumn(
                name: "TableId",
                table: "Table");

            migrationBuilder.DropColumn(
                name: "ColumnId",
                table: "Column");

            migrationBuilder.AddColumn<int>(
                name: "DBSchemaId",
                table: "Table",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TableId",
                table: "Column",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Table_DBSchemaId",
                table: "Table",
                column: "DBSchemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Column_TableId",
                table: "Column",
                column: "TableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Column_Table_TableId",
                table: "Column",
                column: "TableId",
                principalTable: "Table",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Table_DBSchema_DBSchemaId",
                table: "Table",
                column: "DBSchemaId",
                principalTable: "DBSchema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Column_Table_TableId",
                table: "Column");

            migrationBuilder.DropForeignKey(
                name: "FK_Table_DBSchema_DBSchemaId",
                table: "Table");

            migrationBuilder.DropIndex(
                name: "IX_Table_DBSchemaId",
                table: "Table");

            migrationBuilder.DropIndex(
                name: "IX_Column_TableId",
                table: "Column");

            migrationBuilder.DropColumn(
                name: "DBSchemaId",
                table: "Table");

            migrationBuilder.DropColumn(
                name: "TableId",
                table: "Column");

            migrationBuilder.AddColumn<int>(
                name: "TableId",
                table: "Table",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColumnId",
                table: "Column",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Table_TableId",
                table: "Table",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_Column_ColumnId",
                table: "Column",
                column: "ColumnId");

            migrationBuilder.AddForeignKey(
                name: "FK_Column_Table_ColumnId",
                table: "Column",
                column: "ColumnId",
                principalTable: "Table",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Table_DBSchema_TableId",
                table: "Table",
                column: "TableId",
                principalTable: "DBSchema",
                principalColumn: "Id");
        }
    }
}
