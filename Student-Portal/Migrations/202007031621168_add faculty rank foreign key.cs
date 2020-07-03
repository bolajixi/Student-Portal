namespace Student_Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addfacultyrankforeignkey : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FacultyAndRanks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RankId = c.Int(nullable: false),
                        Username = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FacultyRank", t => t.RankId, cascadeDelete: true)
                .Index(t => t.RankId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FacultyAndRanks", "RankId", "dbo.FacultyRank");
            DropIndex("dbo.FacultyAndRanks", new[] { "RankId" });
            DropTable("dbo.FacultyAndRanks");
        }
    }
}
