namespace HistoryData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteHolidayTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Holidays");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Holidays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DAY = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
