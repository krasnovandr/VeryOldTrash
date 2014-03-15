namespace TaskShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBattery : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Batteries", "Model", c => c.String());
            AddColumn("dbo.Earphones", "Model", c => c.String());
            AddColumn("dbo.MemoryCards", "Model", c => c.String());
            AddColumn("dbo.Monitors", "Model", c => c.String());
            AddColumn("dbo.Carts", "Model", c => c.String());
            AddColumn("dbo.Orders", "TotalPrice", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "TotalPrice");
            DropColumn("dbo.Carts", "Model");
            DropColumn("dbo.Monitors", "Model");
            DropColumn("dbo.MemoryCards", "Model");
            DropColumn("dbo.Earphones", "Model");
            DropColumn("dbo.Batteries", "Model");
        }
    }
}
