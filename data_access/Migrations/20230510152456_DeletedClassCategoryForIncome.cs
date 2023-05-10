using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace data_access.Migrations
{
    /// <inheritdoc />
    public partial class DeletedClassCategoryForIncome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories_For_Expense",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ActuallyExpense = table.Column<decimal>(type: "money", nullable: false),
                    PlaneExpense = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories_For_Expense", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlaneAmount = table.Column<decimal>(type: "money", nullable: false),
                    CurrentAmount = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.CheckConstraint("CurrentAmount", "CurrentAmount >= 0");
                    table.CheckConstraint("PlaneAmount", "PlaneAmount >= 0");
                });

            migrationBuilder.CreateTable(
                name: "Incomes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    Month = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseItems", x => x.Id);
                    table.CheckConstraint("Amount", "Amount>= 0");
                    table.ForeignKey(
                        name: "FK_ExpenseItems_Categories_For_Expense_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories_For_Expense",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories_For_Expense",
                columns: new[] { "Id", "ActuallyExpense", "Name", "PlaneExpense" },
                values: new object[,]
                {
                    { 1, 2500m, "Utility payments", 5000m },
                    { 2, 2500m, "Products", 3000m },
                    { 3, 1200m, "Money for the road", 1500m }
                });

            migrationBuilder.InsertData(
                table: "Incomes",
                columns: new[] { "Id", "Amount", "Month", "Name" },
                values: new object[,]
                {
                    { 1, 20000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Salary" },
                    { 2, 20000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deposit" },
                    { 3, 20000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Investment" }
                });

            migrationBuilder.InsertData(
                table: "ExpenseItems",
                columns: new[] { "Id", "Amount", "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, 0m, 1, "Electricity" },
                    { 2, 0m, 2, "Products for the home" },
                    { 3, 0m, 3, "Fuel for cars" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseItems_CategoryId",
                table: "ExpenseItems",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpenseItems");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Incomes");

            migrationBuilder.DropTable(
                name: "Categories_For_Expense");
        }
    }
}
