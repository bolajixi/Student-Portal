namespace Student_Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedforeignkeys : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DeptID = c.Int(nullable: false, identity: true),
                        DeptName = c.String(nullable: false),
                        CollegeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DeptID)
                .ForeignKey("dbo.Colleges", t => t.CollegeId, cascadeDelete: true)
                .Index(t => t.CollegeId);

            //AddColumn("dbo.Course", "DepartmentID", c => c.Int(nullable: false));
            Sql("INSERT INTO dbo.Departments ( DeptName, CollegeId) VALUES ('Center Of Information and Sciences', 1)");
            AddColumn("dbo.Course", "DepartmentID", c => c.Int(nullable: false, defaultValue: 1));
            CreateIndex("dbo.Course", "DepartmentID");
            AddForeignKey("dbo.Course", "DepartmentID", "dbo.Departments", "DeptID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Course", "DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.Departments", "CollegeId", "dbo.Colleges");
            DropIndex("dbo.Course", new[] { "DepartmentID" });
            DropIndex("dbo.Departments", new[] { "CollegeId" });
            DropColumn("dbo.Course", "DepartmentID");
            DropTable("dbo.Departments");
        }
    }
}
