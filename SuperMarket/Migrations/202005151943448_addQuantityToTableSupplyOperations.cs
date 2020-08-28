namespace SuperMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addQuantityToTableSupplyOperations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SupplyOperations", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SupplyOperations", "Quantity");
        }
    }
}
