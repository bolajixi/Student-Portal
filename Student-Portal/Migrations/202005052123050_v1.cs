namespace Student_Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            //DropTable("dbo.ViewUserGrids");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ViewUserGrids",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Name = c.String(),
                        Email = c.String(),
                        Program = c.String(),
                        YearOfJoining = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
