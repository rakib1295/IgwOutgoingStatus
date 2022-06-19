using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IgwOutgoingStatus.Migrations
{
    public partial class CreatingNewTablesInDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Igw_D_Stat_OG_Loss_Record",
                columns: table => new
                {
                    Dest_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dest_Prefix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dest_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calling_Operator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    International_Carrier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total_Min = table.Column<double>(type: "float", nullable: false),
                    Total_Min_Pulse = table.Column<double>(type: "float", nullable: false),
                    Total_Calls = table.Column<int>(type: "int", nullable: false),
                    Carrier_Rate_USD = table.Column<double>(type: "float", nullable: false),
                    Y_Rate_USD = table.Column<double>(type: "float", nullable: false),
                    X_Rate_BDT = table.Column<double>(type: "float", nullable: false),
                    Y_Rate_BDT = table.Column<double>(type: "float", nullable: false),
                    Z_Rate_BDT = table.Column<double>(type: "float", nullable: false),
                    Total_Revenue_BDT = table.Column<double>(type: "float", nullable: false),
                    Total_Expense_USD = table.Column<double>(type: "float", nullable: false),
                    Total_Expense_BDT = table.Column<double>(type: "float", nullable: false),
                    Total_Loss_BDT = table.Column<double>(type: "float", nullable: false),
                    BillingCycle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Partition_Day = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Exchange_Rate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Igw_D_Stat_OG_Prft_Record",
                columns: table => new
                {
                    Dest_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dest_Prefix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dest_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calling_Operator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    International_Carrier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total_Min = table.Column<double>(type: "float", nullable: false),
                    Total_Min_Pulse = table.Column<double>(type: "float", nullable: false),
                    Total_Calls = table.Column<int>(type: "int", nullable: false),
                    Carrier_Rate_USD = table.Column<double>(type: "float", nullable: false),
                    Y_Rate_USD = table.Column<double>(type: "float", nullable: false),
                    X_Rate_BDT = table.Column<double>(type: "float", nullable: false),
                    Y_Rate_BDT = table.Column<double>(type: "float", nullable: false),
                    Z_Rate_BDT = table.Column<double>(type: "float", nullable: false),
                    Total_Revenue_BDT = table.Column<double>(type: "float", nullable: false),
                    Total_Expense_USD = table.Column<double>(type: "float", nullable: false),
                    Total_Expense_BDT = table.Column<double>(type: "float", nullable: false),
                    Total_Profit_BDT = table.Column<double>(type: "float", nullable: false),
                    BillingCycle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Partition_Day = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Exchange_Rate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Igw_D_Stat_OG_Loss_Record");

            migrationBuilder.DropTable(
                name: "Igw_D_Stat_OG_Prft_Record");
        }
    }
}
