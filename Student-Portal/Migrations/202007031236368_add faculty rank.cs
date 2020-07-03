namespace Student_Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addfacultyrank : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FacultyAndRank",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    RankId = c.String(nullable: false),
                    Username = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.FacultyAndRank");
        }
    }
}
