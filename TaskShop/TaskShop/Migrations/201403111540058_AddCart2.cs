namespace TaskShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCart2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "Price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carts", "Price");
        }
    }
}
