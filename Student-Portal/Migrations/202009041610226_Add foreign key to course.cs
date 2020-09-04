namespace Student_Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addforeignkeytocourse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Course", "FacultyId", c => c.Int(nullable: false));
            AlterColumn("dbo.Registered Courses", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Registered Courses", "UserId");
            AddForeignKey("dbo.Registered Courses", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Registered Courses", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Registered Courses", new[] { "UserId" });
            AlterColumn("dbo.Registered Courses", "UserId", c => c.String());
            DropColumn("dbo.Course", "FacultyId");
        }
    }
}
