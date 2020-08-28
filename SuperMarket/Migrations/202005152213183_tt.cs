namespace SuperMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SupplyOperations", "Customer_Id", "dbo.Suppliers");
            DropForeignKey("dbo.SupplyOperations", "Movie_Id", "dbo.Products");
            DropIndex("dbo.SupplyOperations", new[] { "Customer_Id" });
            DropIndex("dbo.SupplyOperations", new[] { "Movie_Id" });
            DropTable("dbo.SupplyOperations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SupplyOperations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SupplayDate = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Customer_Id = c.Int(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.SupplyOperations", "Movie_Id");
            CreateIndex("dbo.SupplyOperations", "Customer_Id");
            AddForeignKey("dbo.SupplyOperations", "Movie_Id", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SupplyOperations", "Customer_Id", "dbo.Suppliers", "Id", cascadeDelete: true);
        }
    }
}
