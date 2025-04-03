using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tmdt.Data.Migrations
{
    /// <inheritdoc />
    public partial class newatt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_Variant_VariantId",
                table: "SanPham");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Variant",
                table: "Variant");

            migrationBuilder.RenameTable(
                name: "Variant",
                newName: "Variants");

            migrationBuilder.AddColumn<int>(
                name: "AttributesId",
                table: "SanPham",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "ManageStock",
                table: "SanPham",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SearchEngineId",
                table: "SanPham",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "SanPham",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StockAvailability",
                table: "SanPham",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TaxClassId",
                table: "SanPham",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Visibility",
                table: "SanPham",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Variants",
                table: "Variants",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AttributeGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SearchEngines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchEngines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttribute",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AttributeCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    IsFilterable = table.Column<bool>(type: "bit", nullable: false),
                    ShowToCustomers = table.Column<bool>(type: "bit", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AttributeGroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttribute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAttribute_AttributeGroup_AttributeGroupId",
                        column: x => x.AttributeGroupId,
                        principalTable: "AttributeGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AttributeOption",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeOption_ProductAttribute_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "ProductAttribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_AttributesId",
                table: "SanPham",
                column: "AttributesId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_SearchEngineId",
                table: "SanPham",
                column: "SearchEngineId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_TaxClassId",
                table: "SanPham",
                column: "TaxClassId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeOption_AttributeId",
                table: "AttributeOption",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttribute_AttributeGroupId",
                table: "ProductAttribute",
                column: "AttributeGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_ProductAttribute_AttributesId",
                table: "SanPham",
                column: "AttributesId",
                principalTable: "ProductAttribute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_SearchEngines_SearchEngineId",
                table: "SanPham",
                column: "SearchEngineId",
                principalTable: "SearchEngines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_TaxClasses_TaxClassId",
                table: "SanPham",
                column: "TaxClassId",
                principalTable: "TaxClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_Variants_VariantId",
                table: "SanPham",
                column: "VariantId",
                principalTable: "Variants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_ProductAttribute_AttributesId",
                table: "SanPham");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_SearchEngines_SearchEngineId",
                table: "SanPham");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_TaxClasses_TaxClassId",
                table: "SanPham");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_Variants_VariantId",
                table: "SanPham");

            migrationBuilder.DropTable(
                name: "AttributeOption");

            migrationBuilder.DropTable(
                name: "SearchEngines");

            migrationBuilder.DropTable(
                name: "TaxClasses");

            migrationBuilder.DropTable(
                name: "ProductAttribute");

            migrationBuilder.DropTable(
                name: "AttributeGroup");

            migrationBuilder.DropIndex(
                name: "IX_SanPham_AttributesId",
                table: "SanPham");

            migrationBuilder.DropIndex(
                name: "IX_SanPham_SearchEngineId",
                table: "SanPham");

            migrationBuilder.DropIndex(
                name: "IX_SanPham_TaxClassId",
                table: "SanPham");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Variants",
                table: "Variants");

            migrationBuilder.DropColumn(
                name: "AttributesId",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "ManageStock",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "SearchEngineId",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "StockAvailability",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "TaxClassId",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "Visibility",
                table: "SanPham");

            migrationBuilder.RenameTable(
                name: "Variants",
                newName: "Variant");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Variant",
                table: "Variant",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_Variant_VariantId",
                table: "SanPham",
                column: "VariantId",
                principalTable: "Variant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
