using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data_access.Migrations
{
    /// <inheritdoc />
    public partial class test_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "Amount1",
                table: "Incomes");

            migrationBuilder.AddColumn<DateTime>(
                name: "Day",
                table: "Expenses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "ExpenseItems",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ActuallyExpense",
                table: "Categories_For_Expense",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PlaneExpense",
                table: "Categories_For_Expense",
                type: "money",
                nullable: false,
                defaultValue: 0m);

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

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 1,
                column: "Day",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Day",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 3,
                column: "Day",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

            migrationBuilder.DropColumn(
                name: "Day",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "ExpenseItems");

            migrationBuilder.DropColumn(
                name: "ActuallyExpense",
                table: "Categories_For_Expense");

            migrationBuilder.DropColumn(
                name: "PlaneExpense",
                table: "Categories_For_Expense");

            migrationBuilder.AddCheckConstraint(
                name: "Amount1",
                table: "Incomes",
                sql: "Amount >= 0");
        }
    }
}
