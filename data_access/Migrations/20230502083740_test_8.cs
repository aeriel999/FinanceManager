using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data_access.Migrations
{
    /// <inheritdoc />
    public partial class test_8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "Amount2",
                table: "Incomes");

            migrationBuilder.DropCheckConstraint(
                name: "Amount1",
                table: "ExpenseItems");

            migrationBuilder.AddCheckConstraint(
                name: "Amount1",
                table: "Incomes",
                sql: "Amount >= 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "Amount1",
                table: "Incomes");

            migrationBuilder.AddCheckConstraint(
                name: "Amount2",
                table: "Incomes",
                sql: "Amount >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "Amount1",
                table: "ExpenseItems",
                sql: "Amount>= 0");
        }
    }
}
