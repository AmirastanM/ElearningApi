using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElearningApi.Migrations
{
    public partial class correctTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Instructor_InstructorId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_InstructorSocial_Instructor_InstructorId",
                table: "InstructorSocial");

            migrationBuilder.DropForeignKey(
                name: "FK_InstructorSocial_Social_SocialId",
                table: "InstructorSocial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Social",
                table: "Social");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InstructorSocial",
                table: "InstructorSocial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instructor",
                table: "Instructor");

            migrationBuilder.RenameTable(
                name: "Social",
                newName: "Socials");

            migrationBuilder.RenameTable(
                name: "InstructorSocial",
                newName: "InstructorSocials");

            migrationBuilder.RenameTable(
                name: "Instructor",
                newName: "Instructors");

            migrationBuilder.RenameIndex(
                name: "IX_InstructorSocial_SocialId",
                table: "InstructorSocials",
                newName: "IX_InstructorSocials_SocialId");

            migrationBuilder.RenameIndex(
                name: "IX_InstructorSocial_InstructorId",
                table: "InstructorSocials",
                newName: "IX_InstructorSocials_InstructorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Socials",
                table: "Socials",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InstructorSocials",
                table: "InstructorSocials",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instructors",
                table: "Instructors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Instructors_InstructorId",
                table: "Courses",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorSocials_Instructors_InstructorId",
                table: "InstructorSocials",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorSocials_Socials_SocialId",
                table: "InstructorSocials",
                column: "SocialId",
                principalTable: "Socials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Instructors_InstructorId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_InstructorSocials_Instructors_InstructorId",
                table: "InstructorSocials");

            migrationBuilder.DropForeignKey(
                name: "FK_InstructorSocials_Socials_SocialId",
                table: "InstructorSocials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Socials",
                table: "Socials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InstructorSocials",
                table: "InstructorSocials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instructors",
                table: "Instructors");

            migrationBuilder.RenameTable(
                name: "Socials",
                newName: "Social");

            migrationBuilder.RenameTable(
                name: "InstructorSocials",
                newName: "InstructorSocial");

            migrationBuilder.RenameTable(
                name: "Instructors",
                newName: "Instructor");

            migrationBuilder.RenameIndex(
                name: "IX_InstructorSocials_SocialId",
                table: "InstructorSocial",
                newName: "IX_InstructorSocial_SocialId");

            migrationBuilder.RenameIndex(
                name: "IX_InstructorSocials_InstructorId",
                table: "InstructorSocial",
                newName: "IX_InstructorSocial_InstructorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Social",
                table: "Social",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InstructorSocial",
                table: "InstructorSocial",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instructor",
                table: "Instructor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Instructor_InstructorId",
                table: "Courses",
                column: "InstructorId",
                principalTable: "Instructor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorSocial_Instructor_InstructorId",
                table: "InstructorSocial",
                column: "InstructorId",
                principalTable: "Instructor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorSocial_Social_SocialId",
                table: "InstructorSocial",
                column: "SocialId",
                principalTable: "Social",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
