namespace FarmersParadise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FarmsAndBarnsToDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Barns",
                c => new
                    {
                        BarnId = c.Int(nullable: false, identity: true),
                        BarnName = c.String(),
                        FarmId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BarnId)
                .ForeignKey("dbo.Farms", t => t.FarmId, cascadeDelete: true)
                .Index(t => t.FarmId);
            
            CreateTable(
                "dbo.Farms",
                c => new
                    {
                        FarmId = c.Int(nullable: false, identity: true),
                        FarmName = c.String(),
                    })
                .PrimaryKey(t => t.FarmId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Barns", "FarmId", "dbo.Farms");
            DropIndex("dbo.Barns", new[] { "FarmId" });
            DropTable("dbo.Farms");
            DropTable("dbo.Barns");
        }
    }
}
