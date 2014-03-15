namespace TaskShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Price : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Batteries", "Price", c => c.Int(nullable: false));
            AlterColumn("dbo.Earphones", "Price", c => c.Int(nullable: false));
            AlterColumn("dbo.MemoryCards", "Price", c => c.Int(nullable: false));
            AlterColumn("dbo.Monitors", "Price", c => c.Int(nullable: false));
            AlterColumn("dbo.Carts", "Price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Carts", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Monitors", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.MemoryCards", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Earphones", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Batteries", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
