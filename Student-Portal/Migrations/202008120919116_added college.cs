namespace Student_Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcollege : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.College", newName: "Colleges");
            AddColumn("dbo.Colleges", "MyProperty", c => c.Int(nullable: false));
            DropColumn("dbo.Colleges", "CollegeName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Colleges", "CollegeName", c => c.String(nullable: false));
            DropColumn("dbo.Colleges", "MyProperty");
            RenameTable(name: "dbo.Colleges", newName: "College");
        }
    }
}
