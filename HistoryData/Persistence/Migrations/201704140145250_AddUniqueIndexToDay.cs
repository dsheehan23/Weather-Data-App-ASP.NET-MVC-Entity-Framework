namespace HistoryData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUniqueIndexToDay : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.History", "DAY", unique: true, name: "Unique Day");
        }
        
        public override void Down()
        {
            DropIndex("dbo.History", "Unique Day");
        }
    }
}
