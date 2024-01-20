using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizAPI.Migrations
{
    /// <inheritdoc />
    public partial class fourth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Options_Questions_questionId",
                table: "Options");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Quizzes_quizId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "OptionId",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Quizzes");

            migrationBuilder.RenameColumn(
                name: "quizId",
                table: "Questions",
                newName: "QuizId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Questions",
                newName: "QuestionName");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_quizId",
                table: "Questions",
                newName: "IX_Questions_QuizId");

            migrationBuilder.RenameColumn(
                name: "questionId",
                table: "Options",
                newName: "QuestionId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Options",
                newName: "OptionName");

            migrationBuilder.RenameIndex(
                name: "IX_Options_questionId",
                table: "Options",
                newName: "IX_Options_QuestionId");

            migrationBuilder.AlterColumn<int>(
                name: "QuizId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "Options",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Questions_QuestionId",
                table: "Options",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Quizzes_QuizId",
                table: "Questions",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Options_Questions_QuestionId",
                table: "Options");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Quizzes_QuizId",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "QuizId",
                table: "Questions",
                newName: "quizId");

            migrationBuilder.RenameColumn(
                name: "QuestionName",
                table: "Questions",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_QuizId",
                table: "Questions",
                newName: "IX_Questions_quizId");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "Options",
                newName: "questionId");

            migrationBuilder.RenameColumn(
                name: "OptionName",
                table: "Options",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_Options_QuestionId",
                table: "Options",
                newName: "IX_Options_questionId");

            migrationBuilder.AddColumn<int>(
                name: "OptionId",
                table: "Quizzes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "Quizzes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "quizId",
                table: "Questions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "questionId",
                table: "Options",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Questions_questionId",
                table: "Options",
                column: "questionId",
                principalTable: "Questions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Quizzes_quizId",
                table: "Questions",
                column: "quizId",
                principalTable: "Quizzes",
                principalColumn: "Id");
        }
    }
}
