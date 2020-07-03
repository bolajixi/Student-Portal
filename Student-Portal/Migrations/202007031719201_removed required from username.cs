namespace Student_Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedrequiredfromusername : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FacultyAndRanks", "Username", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FacultyAndRanks", "Username", c => c.String(nullable: false));
        }
    }
}
