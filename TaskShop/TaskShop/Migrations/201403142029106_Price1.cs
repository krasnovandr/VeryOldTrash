namespace TaskShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Price1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "TotalGoodsPrice", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "DeliveryPrice", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "TotalPrice", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "TotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Orders", "DeliveryPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Orders", "TotalGoodsPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
