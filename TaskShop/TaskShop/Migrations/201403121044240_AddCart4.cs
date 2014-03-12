namespace TaskShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCart4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "OrderId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carts", "OrderId");
        }
    }
}
