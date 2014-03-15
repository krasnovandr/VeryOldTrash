namespace TaskShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPrice : DbMigration
    {
        public override void Up()
        {
            //AlterColumn("dbo.Batteries", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            //AlterColumn("dbo.Earphones", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            //AlterColumn("dbo.MemoryCards", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            //AlterColumn("dbo.Monitors", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            //AlterColumn("dbo.Carts", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            //AlterColumn("dbo.Orders", "TotalGoodsPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            //AlterColumn("dbo.Orders", "DeliveryPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            //AlterColumn("dbo.Orders", "TotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            //AlterColumn("dbo.Orders", "TotalPrice", c => c.Int(nullable: false));
            //AlterColumn("dbo.Orders", "DeliveryPrice", c => c.Int(nullable: false));
            //AlterColumn("dbo.Orders", "TotalGoodsPrice", c => c.Int(nullable: false));
            //AlterColumn("dbo.Carts", "Price", c => c.Int(nullable: false));
            //AlterColumn("dbo.Monitors", "Price", c => c.Int(nullable: false));
            //AlterColumn("dbo.MemoryCards", "Price", c => c.Int(nullable: false));
            //AlterColumn("dbo.Earphones", "Price", c => c.Int(nullable: false));
            //AlterColumn("dbo.Batteries", "Price", c => c.Int(nullable: false));
        }
    }
}
