namespace HistoryData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'445718f1-5db7-4090-8571-d5341fe2eb45', N'admin@DansWeatherData.com', 0, N'ALMQkuWx1yMLC9Y906jXDlB7e/nsqfPpbVg17NLzQ/u2h9OLC3bTsOMg0fh1DzdQSw==', N'ad80550c-ce9d-4b8d-827b-84990b968bdb', NULL, 0, 0, NULL, 1, 0, N'admin@DansWeatherData.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ba7f2402-e87a-414d-899d-68f6e011b06f', N'guest@DansWeatherData.com', 0, N'ANiBACGZAjqCWCkBcE7/Zi1OL2SLzUK//beM9y3wjIV4+es9MUtgY0BNDlSxm+Ce2Q==', N'e66c67c1-137e-483f-b39d-e05cffbcfaf9', NULL, 0, 0, NULL, 1, 0, N'guest@DansWeatherData.com')

            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'35741062-ab8f-4ecb-a510-cffdda2e72e8', N'CanManageRecords')

            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'445718f1-5db7-4090-8571-d5341fe2eb45', N'35741062-ab8f-4ecb-a510-cffdda2e72e8')
");
        }
        
        public override void Down()
        {
        }
    }
}
