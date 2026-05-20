using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HireHubInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_User_UserId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplication_Applications_SeekerId",
                table: "JobApplication");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Applications",
                table: "Applications");

            migrationBuilder.RenameTable(
                name: "Applications",
                newName: "SeekerProfiles");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_UserId",
                table: "SeekerProfiles",
                newName: "IX_SeekerProfiles_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeekerProfiles",
                table: "SeekerProfiles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplication_SeekerProfiles_SeekerId",
                table: "JobApplication",
                column: "SeekerId",
                principalTable: "SeekerProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeekerProfiles_User_UserId",
                table: "SeekerProfiles",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplication_SeekerProfiles_SeekerId",
                table: "JobApplication");

            migrationBuilder.DropForeignKey(
                name: "FK_SeekerProfiles_User_UserId",
                table: "SeekerProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SeekerProfiles",
                table: "SeekerProfiles");

            migrationBuilder.RenameTable(
                name: "SeekerProfiles",
                newName: "Applications");

            migrationBuilder.RenameIndex(
                name: "IX_SeekerProfiles_UserId",
                table: "Applications",
                newName: "IX_Applications_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applications",
                table: "Applications",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_User_UserId",
                table: "Applications",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplication_Applications_SeekerId",
                table: "JobApplication",
                column: "SeekerId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
