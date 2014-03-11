namespace TaskShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Batteries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Producer = c.String(),
                        Capacity = c.Int(nullable: false),
                        Voltage = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Earphones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Producer = c.String(),
                        CableLength = c.Double(nullable: false),
                        Resistance = c.Int(nullable: false),
                        MaxFrequency = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MemoryCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Producer = c.String(),
                        Size = c.Int(nullable: false),
                        WriteSpeed = c.Int(nullable: false),
                        ReadSpeed = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Monitors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Producer = c.String(),
                        Resolution = c.String(),
                        Frequency = c.Int(nullable: false),
                        MatrixType = c.String(),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Monitors");
            DropTable("dbo.MemoryCards");
            DropTable("dbo.Earphones");
            DropTable("dbo.Batteries");
        }
    }
}
