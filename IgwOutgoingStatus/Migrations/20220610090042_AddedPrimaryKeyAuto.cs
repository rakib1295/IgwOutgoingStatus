using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IgwOutgoingStatus.Migrations
{
    public partial class AddedPrimaryKeyAuto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Igw_D_Stat_OG_Prft_Record",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Igw_D_Stat_OG_Loss_Record",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Igw_D_Stat_OG_Prft_Record",
                table: "Igw_D_Stat_OG_Prft_Record",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Igw_D_Stat_OG_Loss_Record",
                table: "Igw_D_Stat_OG_Loss_Record",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Igw_D_Stat_OG_Prft_Record",
                table: "Igw_D_Stat_OG_Prft_Record");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Igw_D_Stat_OG_Loss_Record",
                table: "Igw_D_Stat_OG_Loss_Record");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Igw_D_Stat_OG_Prft_Record");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Igw_D_Stat_OG_Loss_Record");
        }
    }
}
