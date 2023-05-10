using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data_access.Migrations
{
    /// <inheritdoc />
    public partial class statistic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Categories_For_Expense_Category_for_expenseId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_Category_for_expenseId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "Category_for_expenseId",
                table: "Expenses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Category_for_expenseId",
                table: "Expenses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_Category_for_expenseId",
                table: "Expenses",
                column: "Category_for_expenseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Categories_For_Expense_Category_for_expenseId",
                table: "Expenses",
                column: "Category_for_expenseId",
                principalTable: "Categories_For_Expense",
                principalColumn: "Id");
        }
    }
}
