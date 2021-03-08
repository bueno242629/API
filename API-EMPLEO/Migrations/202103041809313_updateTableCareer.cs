namespace API_EMPLEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTableCareer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CAREERS", "area", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CAREERS", "area");
        }
    }
}
