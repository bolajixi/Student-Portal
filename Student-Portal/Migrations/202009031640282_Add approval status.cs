namespace Student_Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addapprovalstatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Registered Courses", "ApprovalStatus", c => c.Boolean(nullable: false, defaultValue: false));
            AddColumn("dbo.Registered Courses", "ApprovalDate", c => c.String());
            AddColumn("dbo.Registered Courses", "ApprovedBy", c => c.String());
            AddColumn("dbo.AspNetUsers", "Course_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Course_Id");
            AddForeignKey("dbo.AspNetUsers", "Course_Id", "dbo.Course", "CourseId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Course_Id", "dbo.Course");
            DropIndex("dbo.AspNetUsers", new[] { "Course_Id" });
            DropColumn("dbo.AspNetUsers", "Course_Id");
            DropColumn("dbo.Registered Courses", "ApprovedBy");
            DropColumn("dbo.Registered Courses", "ApprovalDate");
            DropColumn("dbo.Registered Courses", "ApprovalStatus");
        }
    }
}
