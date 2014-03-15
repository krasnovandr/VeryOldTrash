namespace TaskShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Carts", "Model");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carts", "Model", c => c.String());
        }
    }
}
