using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletManagerApi.Migrations
{
    public partial class updatedTransactionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TransactionAmount",
                table: "TransactionHistories",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionAmount",
                table: "TransactionHistories");
        }
    }
}
