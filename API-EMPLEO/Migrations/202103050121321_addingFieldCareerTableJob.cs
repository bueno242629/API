namespace API_EMPLEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingFieldCareerTableJob : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JOB", "career", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JOB", "career");
        }
    }
}
