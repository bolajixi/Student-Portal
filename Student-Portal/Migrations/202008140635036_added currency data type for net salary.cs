namespace Student_Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcurrencydatatypefornetsalary : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Salaries", "Username", c => c.String());
            AlterColumn("dbo.Salaries", "NetSalary", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.SalaryStructures", "NetSalary", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SalaryStructures", "NetSalary", c => c.Int(nullable: false));
            AlterColumn("dbo.Salaries", "NetSalary", c => c.Int(nullable: false));
            AlterColumn("dbo.Salaries", "Username", c => c.Int(nullable: false));
        }
    }
}
