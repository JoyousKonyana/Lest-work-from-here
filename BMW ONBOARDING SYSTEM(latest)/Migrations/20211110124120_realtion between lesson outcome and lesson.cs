using Microsoft.EntityFrameworkCore.Migrations;

namespace BMW_ONBOARDING_SYSTEM.Migrations
{
    public partial class realtionbetweenlessonoutcomeandlesson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_LessonContent_LessonOutcomeID",
                table: "LessonContent",
                column: "LessonOutcomeID");

            migrationBuilder.AddForeignKey(
                name: "FK_LessonContent_LessonOutcome_LessonOutcomeID",
                table: "LessonContent",
                column: "LessonOutcomeID",
                principalTable: "LessonOutcome",
                principalColumn: "LessonOutcomeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LessonContent_LessonOutcome_LessonOutcomeID",
                table: "LessonContent");

            migrationBuilder.DropIndex(
                name: "IX_LessonContent_LessonOutcomeID",
                table: "LessonContent");
        }
    }
}
