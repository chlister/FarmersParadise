namespace FarmersParadise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Farms VALUES ('JensHansens Gaards')");
        }
        
        public override void Down()
        {
        }
    }
}
