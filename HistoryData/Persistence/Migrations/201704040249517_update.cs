namespace HistoryData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.History", new[] { "DAY" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.History", "DAY", unique: true);
        }
    }
}
