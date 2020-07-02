namespace Student_Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_rank : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.FacultyRank", name: "Rank", newName: "Ranks");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.FacultyRank", name: "Ranks", newName: "Rank");
        }
    }
}
