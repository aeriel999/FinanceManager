using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace data_access.Migrations
{
    /// <inheritdoc />
    public partial class test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category_For_Incomes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category_For_Incomes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseItems_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Month = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.CheckConstraint("Amount", "Amount >= 0");
                    table.ForeignKey(
                        name: "FK_Expenses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incomes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Month = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IncomeCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomes", x => x.Id);
                    table.CheckConstraint("Amount1", "Amount >= 0");
                    table.ForeignKey(
                        name: "FK_Incomes_Category_For_Incomes_IncomeCategoryId",
                        column: x => x.IncomeCategoryId,
                        principalTable: "Category_For_Incomes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Utility payments" },
                    { 2, "Products" },
                    { 3, "Money for the road" }
                });

            migrationBuilder.InsertData(
                table: "Category_For_Incomes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Salary" },
                    { 2, "Deposit" },
                    { 3, "Investment" }
                });

            migrationBuilder.InsertData(
                table: "ExpenseItems",
                columns: new[] { "Id", "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Electricity" },
                    { 2, 2, "Products for the home" },
                    { 3, 3, "Fuel for cars" }
                });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Amount", "CategoryId", "Month", "Year" },
                values: new object[,]
                {
                    { 1, 1000m, 3, "April", 2023 },
                    { 2, 3000m, 2, "April", 2023 },
                    { 3, 2000m, 1, "April", 2023 }
                });

            migrationBuilder.InsertData(
                table: "Incomes",
                columns: new[] { "Id", "Amount", "IncomeCategoryId", "Month", "Year" },
                values: new object[,]
                {
                    { 1, 20000m, 1, "March", 2023 },
                    { 2, 5000m, 2, "March", 2023 },
                    { 3, 10000m, 3, "March", 2023 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseItems_CategoryId",
                table: "ExpenseItems",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CategoryId",
                table: "Expenses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_IncomeCategoryId",
                table: "Incomes",
                column: "IncomeCategoryId");
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
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Category_For_Incomes");
        }
    }
}
