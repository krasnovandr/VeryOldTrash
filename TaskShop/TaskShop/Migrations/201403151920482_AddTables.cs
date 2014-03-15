namespace TaskShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Commodities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(),
                        Producer = c.String(),
                        Price = c.Int(nullable: false),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ValueChar = c.String(),
                        ValueInt = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GoodsProperties",
                c => new
                    {
                        GoodsId = c.Int(nullable: false),
                        PropertyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GoodsId, t.PropertyId })
                .ForeignKey("dbo.Properties", t => t.GoodsId, cascadeDelete: true)
                .ForeignKey("dbo.Commodities", t => t.PropertyId, cascadeDelete: true)
                .Index(t => t.GoodsId)
                .Index(t => t.PropertyId);
            
            DropTable("dbo.Batteries");
            DropTable("dbo.Earphones");
            DropTable("dbo.MemoryCards");
            DropTable("dbo.Monitors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Monitors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(),
                        Producer = c.String(),
                        Resolution = c.String(),
                        Frequency = c.Int(nullable: false),
                        MatrixType = c.String(),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MemoryCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(),
                        Producer = c.String(),
                        Size = c.Int(nullable: false),
                        WriteSpeed = c.Int(nullable: false),
                        ReadSpeed = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Earphones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(),
                        Producer = c.String(),
                        CableLength = c.Double(nullable: false),
                        Resistance = c.Int(nullable: false),
                        MaxFrequency = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Batteries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(),
                        Producer = c.String(),
                        Capacity = c.Int(nullable: false),
                        Voltage = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.GoodsProperties", "PropertyId", "dbo.Commodities");
            DropForeignKey("dbo.GoodsProperties", "GoodsId", "dbo.Properties");
            DropIndex("dbo.GoodsProperties", new[] { "PropertyId" });
            DropIndex("dbo.GoodsProperties", new[] { "GoodsId" });
            DropTable("dbo.GoodsProperties");
            DropTable("dbo.Properties");
            DropTable("dbo.Commodities");
        }
    }
}
