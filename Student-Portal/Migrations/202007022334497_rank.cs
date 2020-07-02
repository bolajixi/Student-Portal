namespace Student_Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rank : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FacultyRank",
                c => new
                    {
                        RankId = c.Int(nullable: false, identity: true),
                        Rank = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RankId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FacultyRank");
        }
    }
}
