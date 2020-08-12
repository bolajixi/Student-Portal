namespace Student_Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcollege : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Colleges", "CollegeCode", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Colleges", "CollegeCode");
        }
    }
}
