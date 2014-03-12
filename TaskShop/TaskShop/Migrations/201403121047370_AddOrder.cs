namespace TaskShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalGoodsPrice = c.Int(nullable: false),
                        DeliveryPrice = c.Int(nullable: false),
                        TotalCount = c.Int(nullable: false),
                        Discount = c.Int(nullable: false),
                        Email = c.String(),
                        City = c.String(),
                        Street = c.String(),
                        House = c.Int(nullable: false),
                        CardNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Orders");
        }
    }
}
