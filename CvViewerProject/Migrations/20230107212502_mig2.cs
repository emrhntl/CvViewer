using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CvViewerProject.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_person_educations_person_educations_PersonEduperson_id_Pers~",
                table: "person_educations");

            migrationBuilder.DropIndex(
                name: "IX_person_educations_PersonEduperson_id_PersonEduedu_id",
                table: "person_educations");

            migrationBuilder.DropColumn(
                name: "PersonEduedu_id",
                table: "person_educations");

            migrationBuilder.DropColumn(
                name: "PersonEduperson_id",
                table: "person_educations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonEduedu_id",
                table: "person_educations",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonEduperson_id",
                table: "person_educations",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_person_educations_PersonEduperson_id_PersonEduedu_id",
                table: "person_educations",
                columns: new[] { "PersonEduperson_id", "PersonEduedu_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_person_educations_person_educations_PersonEduperson_id_Pers~",
                table: "person_educations",
                columns: new[] { "PersonEduperson_id", "PersonEduedu_id" },
                principalTable: "person_educations",
                principalColumns: new[] { "person_id", "edu_id" });
        }
    }
}
