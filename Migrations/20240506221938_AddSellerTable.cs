using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace by_my_hand.Migrations
{
    /// <inheritdoc />
    public partial class AddSellerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sellers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),

                    nationalId = table.Column<int>(type: "int", nullable: false),

                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),

                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),

                    BusinessName = table.Column<string>(type: "nvarchar(max)", nullable: false),

                    BusinessType = table.Column<string>(type: "nvarchar(max)", nullable: false),

                    BusinessAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),

                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),

                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),

                    taxId = table.Column<int>(type: "int", nullable: false),

                    SocialsLinks = table.Column<string>(type: "nvarchar(max)", nullable: false),

                    TypeOfProduct = table.Column<string>(type: "nvarchar(max)", nullable: false),

                    ProductPhoto = table.Column<byte[]>(type: "varbinary(max)", nullable: false),

                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),

                    Pricing = table.Column<string>(type: "nvarchar(max)", nullable: false),

                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),

                    ShippingMedthod = table.Column<string>(type: "nvarchar(max)", nullable: false),

                    ShippingCost = table.Column<int>(type: "int", nullable: false),

                    Estimated = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sellers", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sellers");
        }
    }
}
