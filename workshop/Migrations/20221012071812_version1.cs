using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workshop.Migrations
{
    public partial class version1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserEntitys",
                columns: table => new
                {
                    UserEntityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserCode = table.Column<string>(type: "varchar(50)", nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", nullable: true),
                    Organization_Code = table.Column<string>(type: "varchar(50)", nullable: true),
                    Organization_Name_TH = table.Column<string>(type: "varchar(250)", nullable: true),
                    FullName = table.Column<string>(type: "varchar(250)", nullable: true),
                    PersonalID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserStage = table.Column<int>(type: "int", nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    LineId = table.Column<string>(type: "varchar(50)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SMSOTP = table.Column<string>(type: "varchar(20)", nullable: true),
                    SMSOTPRef = table.Column<string>(type: "varchar(20)", nullable: true),
                    SMSExpire = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmailOTP = table.Column<string>(type: "varchar(20)", nullable: true),
                    EmailOTPRef = table.Column<string>(type: "varchar(20)", nullable: true),
                    IsConfirmEmail = table.Column<bool>(type: "bit", nullable: false),
                    IsDeactivate = table.Column<bool>(type: "bit", nullable: false),
                    IsReactivate = table.Column<bool>(type: "bit", nullable: false),
                    ConfirmEmailTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsConfirmTel = table.Column<bool>(type: "bit", nullable: false),
                    ConfirmTelTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsConfirmPersonalID = table.Column<bool>(type: "bit", nullable: false),
                    ConfirmPersonalIDTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fileNamePersonalID = table.Column<string>(type: "varchar(100)", nullable: true),
                    fullPathPersonalID = table.Column<string>(type: "varchar(100)", nullable: true),
                    dbPathPersonalID = table.Column<string>(type: "varchar(100)", nullable: true),
                    IsConfirmKYC = table.Column<bool>(type: "bit", nullable: false),
                    ConfirmKYCTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fileNameKYC = table.Column<string>(type: "varchar(100)", nullable: true),
                    fullPathKYC = table.Column<string>(type: "varchar(100)", nullable: true),
                    dbPathKYC = table.Column<string>(type: "varchar(100)", nullable: true),
                    fileNameFace = table.Column<string>(type: "varchar(100)", nullable: true),
                    fullPathFace = table.Column<string>(type: "varchar(100)", nullable: true),
                    dbPathFace = table.Column<string>(type: "varchar(100)", nullable: true),
                    faceData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminApproved = table.Column<string>(type: "varchar(50)", nullable: true),
                    AdminApprovedIP = table.Column<string>(type: "varchar(50)", nullable: true),
                    AdminNotApproved = table.Column<string>(type: "varchar(50)", nullable: true),
                    AdminNotApprovedIP = table.Column<string>(type: "varchar(50)", nullable: true),
                    CommetNotApproved = table.Column<string>(type: "varchar(50)", nullable: true),
                    ApprovedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NotApprovedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AdminDeactivate = table.Column<string>(type: "varchar(50)", nullable: true),
                    AdminDeactivateIP = table.Column<string>(type: "varchar(50)", nullable: true),
                    DeactivateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AdminReactivate = table.Column<string>(type: "varchar(50)", nullable: true),
                    AdminReactivateIP = table.Column<string>(type: "varchar(50)", nullable: true),
                    ReactivateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Access_token = table.Column<string>(type: "varchar(50)", nullable: true),
                    Refresh_token = table.Column<string>(type: "varchar(50)", nullable: true),
                    Expires_in = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEntitys", x => x.UserEntityId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserEntitys");
        }
    }
}
