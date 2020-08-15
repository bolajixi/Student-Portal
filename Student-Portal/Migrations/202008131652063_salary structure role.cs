namespace Student_Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class salarystructurerole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SalaryStructures", "Role", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SalaryStructures", "Role");
        }
    }
}
