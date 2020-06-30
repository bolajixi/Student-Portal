namespace Student_Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class registerstamp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Registered Courses", "EnrollmentDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Registered Courses", "EnrollmentDate");
        }
    }
}
