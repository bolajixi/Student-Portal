namespace Student_Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removefacultyrank : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FacultyAndRanks", "RankId", "dbo.FacultyRank");
            DropIndex("dbo.FacultyAndRanks", new[] { "RankId" });
            DropTable("dbo.FacultyAndRanks");
            DropTable("dbo.FacultyRank");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FacultyRank",
                c => new
                    {
                        RankId = c.Int(nullable: false, identity: true),
                        Ranks = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RankId);
            
            CreateTable(
                "dbo.FacultyAndRanks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RankId = c.Int(nullable: false),
                        Username = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.FacultyAndRanks", "RankId");
            AddForeignKey("dbo.FacultyAndRanks", "RankId", "dbo.FacultyRank", "RankId", cascadeDelete: true);
        }
    }
}
