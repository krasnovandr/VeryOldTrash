namespace TaskShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCart3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "Count", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carts", "Count");
        }
    }
}
