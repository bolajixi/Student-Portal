namespace Student_Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v11 : DbMigration
    {
        public override void Up()
        {
        }
        
        public override void Down()
        {
            AddColumn("dbo.ViewUserGrids", "ApplicationUserManager_DefaultAccountLockoutTimeSpan", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.ViewUserGrids", "ApplicationUserManager_MaxFailedAccessAttemptsBeforeLockout", c => c.Int(nullable: false));
            AddColumn("dbo.ViewUserGrids", "ApplicationUserManager_UserLockoutEnabledByDefault", c => c.Boolean(nullable: false));
        }
    }
}
