namespace SuperMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTableSupplyOperations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SupplyOperations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SupplayDate = c.DateTime(nullable: false),
                        Customer_Id = c.Int(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Suppliers", t => t.Customer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Movie_Id, cascadeDelete: true)
                .Index(t => t.Customer_Id)
                .Index(t => t.Movie_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SupplyOperations", "Movie_Id", "dbo.Products");
            DropForeignKey("dbo.SupplyOperations", "Customer_Id", "dbo.Suppliers");
            DropIndex("dbo.SupplyOperations", new[] { "Movie_Id" });
            DropIndex("dbo.SupplyOperations", new[] { "Customer_Id" });
            DropTable("dbo.SupplyOperations");
        }
    }
}
