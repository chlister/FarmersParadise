namespace FarmersParadise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDbClasses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Barns",
                c => new
                    {
                        BarnId = c.Int(nullable: false, identity: true),
                        BarnName = c.String(),
                        Farm_FarmId = c.Int(),
                    })
                .PrimaryKey(t => t.BarnId)
                .ForeignKey("dbo.Farms", t => t.Farm_FarmId)
                .Index(t => t.Farm_FarmId);
            
            CreateTable(
                "dbo.Boxes",
                c => new
                    {
                        BoxId = c.Int(nullable: false, identity: true),
                        BoxName = c.String(),
                        BoxType = c.Int(nullable: false),
                        Barn_BarnId = c.Int(),
                    })
                .PrimaryKey(t => t.BoxId)
                .ForeignKey("dbo.Barns", t => t.Barn_BarnId)
                .Index(t => t.Barn_BarnId);
            
            CreateTable(
                "dbo.Pigs",
                c => new
                    {
                        PigId = c.Int(nullable: false, identity: true),
                        CHRTag = c.Int(nullable: false),
                        PigType = c.Int(nullable: false),
                        Box_BoxId = c.Int(),
                    })
                .PrimaryKey(t => t.PigId)
                .ForeignKey("dbo.Boxes", t => t.Box_BoxId)
                .Index(t => t.Box_BoxId);
            
            CreateTable(
                "dbo.Farms",
                c => new
                    {
                        FarmId = c.Int(nullable: false, identity: true),
                        FarmName = c.String(),
                    })
                .PrimaryKey(t => t.FarmId);
            
            CreateTable(
                "dbo.TemperatureSensors",
                c => new
                    {
                        SensorId = c.Int(nullable: false, identity: true),
                        SensorName = c.String(),
                        MacAddress = c.String(nullable: false),
                        Barn_BarnId = c.Int(),
                    })
                .PrimaryKey(t => t.SensorId)
                .ForeignKey("dbo.Barns", t => t.Barn_BarnId)
                .Index(t => t.Barn_BarnId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TemperatureSensors", "Barn_BarnId", "dbo.Barns");
            DropForeignKey("dbo.Barns", "Farm_FarmId", "dbo.Farms");
            DropForeignKey("dbo.Pigs", "Box_BoxId", "dbo.Boxes");
            DropForeignKey("dbo.Boxes", "Barn_BarnId", "dbo.Barns");
            DropIndex("dbo.TemperatureSensors", new[] { "Barn_BarnId" });
            DropIndex("dbo.Pigs", new[] { "Box_BoxId" });
            DropIndex("dbo.Boxes", new[] { "Barn_BarnId" });
            DropIndex("dbo.Barns", new[] { "Farm_FarmId" });
            DropTable("dbo.TemperatureSensors");
            DropTable("dbo.Farms");
            DropTable("dbo.Pigs");
            DropTable("dbo.Boxes");
            DropTable("dbo.Barns");
        }
    }
}
