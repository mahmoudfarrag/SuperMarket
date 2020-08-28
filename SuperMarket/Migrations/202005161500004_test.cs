namespace SuperMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SupplyOperations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SupplayDate = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                        Supplier_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.Supplier_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SupplyOperations", "Supplier_Id", "dbo.Suppliers");
            DropForeignKey("dbo.SupplyOperations", "Product_Id", "dbo.Products");
            DropIndex("dbo.SupplyOperations", new[] { "Supplier_Id" });
            DropIndex("dbo.SupplyOperations", new[] { "Product_Id" });
            DropTable("dbo.SupplyOperations");
        }
    }
}
