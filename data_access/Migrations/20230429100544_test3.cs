using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data_access.Migrations
{
    /// <inheritdoc />
    public partial class test3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseItems_Categories_CategoryId",
                table: "ExpenseItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Categories_CategoryId",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Categories_For_Expense");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories_For_Expense",
                table: "Categories_For_Expense",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseItems_Categories_For_Expense_CategoryId",
                table: "ExpenseItems",
                column: "CategoryId",
                principalTable: "Categories_For_Expense",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Categories_For_Expense_CategoryId",
                table: "Expenses",
                column: "CategoryId",
                principalTable: "Categories_For_Expense",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseItems_Categories_For_Expense_CategoryId",
                table: "ExpenseItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Categories_For_Expense_CategoryId",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories_For_Expense",
                table: "Categories_For_Expense");

            migrationBuilder.RenameTable(
                name: "Categories_For_Expense",
                newName: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseItems_Categories_CategoryId",
                table: "ExpenseItems",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Categories_CategoryId",
                table: "Expenses",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
