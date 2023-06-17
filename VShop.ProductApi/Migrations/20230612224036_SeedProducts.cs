using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VShop.ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Products (Name, Price, Description, Stock , ImageUrl, CategoryId)" +
                "Values('Caderno', 10.00, 'Acessórios', 10, 'caderno1.jpg', 1)" );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from products");
        }
    }
}
