namespace FarmersParadise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BoxesAndPigsToDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Boxes",
                c => new
                    {
                        BoxId = c.Int(nullable: false, identity: true),
                        BoxName = c.String(),
                        BoxType = c.Int(nullable: false),
                        BarnId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BoxId)
                .ForeignKey("dbo.Barns", t => t.BarnId, cascadeDelete: true)
                .Index(t => t.BarnId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pigs", "Box_BoxId", "dbo.Boxes");
            DropForeignKey("dbo.Boxes", "BarnId", "dbo.Barns");
            DropIndex("dbo.Pigs", new[] { "Box_BoxId" });
            DropIndex("dbo.Boxes", new[] { "BarnId" });
            DropTable("dbo.Pigs");
            DropTable("dbo.Boxes");
        }
    }
}
