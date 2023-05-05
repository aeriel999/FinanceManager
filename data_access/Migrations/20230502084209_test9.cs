using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data_access.Migrations
{
    /// <inheritdoc />
    public partial class test9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "Amount1",
                table: "Incomes");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "ExpenseItems",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PlaneExpense",
                table: "Categories_For_Expense",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ActuallyExpense",
                table: "Categories_For_Expense",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "Categories_For_Expense",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ActuallyExpense", "PlaneExpense" },
                values: new object[] { 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Categories_For_Expense",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ActuallyExpense", "PlaneExpense" },
                values: new object[] { 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Categories_For_Expense",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ActuallyExpense", "PlaneExpense" },
                values: new object[] { 0m, 0m });

            migrationBuilder.UpdateData(
                table: "ExpenseItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Amount",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "ExpenseItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Amount",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "ExpenseItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Amount",
                value: 0m);

            migrationBuilder.AddCheckConstraint(
                name: "Amount2",
                table: "Incomes",
                sql: "Amount >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "Amount1",
                table: "ExpenseItems",
                sql: "Amount>= 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "Amount2",
                table: "Incomes");

            migrationBuilder.DropCheckConstraint(
                name: "Amount1",
                table: "ExpenseItems");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "ExpenseItems",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "PlaneExpense",
                table: "Categories_For_Expense",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "ActuallyExpense",
                table: "Categories_For_Expense",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.UpdateData(
                table: "Categories_For_Expense",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ActuallyExpense", "PlaneExpense" },
                values: new object[] { 2500m, 5000m });

            migrationBuilder.UpdateData(
                table: "Categories_For_Expense",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ActuallyExpense", "PlaneExpense" },
                values: new object[] { 2500m, 3000m });

            migrationBuilder.UpdateData(
                table: "Categories_For_Expense",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ActuallyExpense", "PlaneExpense" },
                values: new object[] { 1200m, 1500m });

            migrationBuilder.UpdateData(
                table: "ExpenseItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Amount",
                value: 2500m);

            migrationBuilder.UpdateData(
                table: "ExpenseItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Amount",
                value: 2500m);

            migrationBuilder.UpdateData(
                table: "ExpenseItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Amount",
                value: 1200m);

            migrationBuilder.AddCheckConstraint(
                name: "Amount1",
                table: "Incomes",
                sql: "Amount >= 0");
        }
    }
}
