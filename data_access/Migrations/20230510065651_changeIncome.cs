using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace data_access.Migrations
{
    /// <inheritdoc />
    public partial class changeIncome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_Category_For_Incomes_IncomeCategoryId",
                table: "Incomes");

            migrationBuilder.DropTable(
                name: "IncomeItems");

            migrationBuilder.RenameColumn(
                name: "IncomeCategoryId",
                table: "Incomes",
                newName: "Category_for_IncomeId");

            migrationBuilder.RenameIndex(
                name: "IX_Incomes_IncomeCategoryId",
                table: "Incomes",
                newName: "IX_Incomes_Category_for_IncomeId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Incomes_Category_For_Incomes_Category_for_IncomeId",
                table: "Incomes",
                column: "Category_for_IncomeId",
                principalTable: "Category_For_Incomes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_Category_For_Incomes_Category_for_IncomeId",
                table: "Incomes");

            migrationBuilder.RenameColumn(
                name: "Category_for_IncomeId",
                table: "Incomes",
                newName: "IncomeCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Incomes_Category_for_IncomeId",
                table: "Incomes",
                newName: "IX_Incomes_IncomeCategoryId");

            migrationBuilder.CreateTable(
                name: "IncomeItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeItems", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "IncomeItems",
                columns: new[] { "Id", "Amount", "Name" },
                values: new object[,]
                {
                    { 1, 20000m, "Salary" },
                    { 2, 5000m, "Deposit" },
                    { 3, 10000m, "Investment" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Incomes_Category_For_Incomes_IncomeCategoryId",
                table: "Incomes",
                column: "IncomeCategoryId",
                principalTable: "Category_For_Incomes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
