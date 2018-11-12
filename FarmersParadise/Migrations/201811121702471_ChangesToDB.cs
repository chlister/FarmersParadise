namespace FarmersParadise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesToDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Boxes", "Barn_BarnId", "dbo.Barns");
            DropForeignKey("dbo.Barns", "Farm_FarmId", "dbo.Farms");
            DropIndex("dbo.Barns", new[] { "Farm_FarmId" });
            DropIndex("dbo.Boxes", new[] { "Barn_BarnId" });
            RenameColumn(table: "dbo.Boxes", name: "Barn_BarnId", newName: "BarnId");
            RenameColumn(table: "dbo.Barns", name: "Farm_FarmId", newName: "FarmId");
            AlterColumn("dbo.Barns", "FarmId", c => c.Int(nullable: false));
            AlterColumn("dbo.Boxes", "BarnId", c => c.Int(nullable: false));
            CreateIndex("dbo.Barns", "FarmId");
            CreateIndex("dbo.Boxes", "BarnId");
            AddForeignKey("dbo.Boxes", "BarnId", "dbo.Barns", "BarnId", cascadeDelete: true);
            AddForeignKey("dbo.Barns", "FarmId", "dbo.Farms", "FarmId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Barns", "FarmId", "dbo.Farms");
            DropForeignKey("dbo.Boxes", "BarnId", "dbo.Barns");
            DropIndex("dbo.Boxes", new[] { "BarnId" });
            DropIndex("dbo.Barns", new[] { "FarmId" });
            AlterColumn("dbo.Boxes", "BarnId", c => c.Int());
            AlterColumn("dbo.Barns", "FarmId", c => c.Int());
            RenameColumn(table: "dbo.Barns", name: "FarmId", newName: "Farm_FarmId");
            RenameColumn(table: "dbo.Boxes", name: "BarnId", newName: "Barn_BarnId");
            CreateIndex("dbo.Boxes", "Barn_BarnId");
            CreateIndex("dbo.Barns", "Farm_FarmId");
            AddForeignKey("dbo.Barns", "Farm_FarmId", "dbo.Farms", "FarmId");
            AddForeignKey("dbo.Boxes", "Barn_BarnId", "dbo.Barns", "BarnId");
        }
    }
}
