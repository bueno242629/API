namespace API_EMPLEO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTableCareer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CAREERS",
                c => new
                    {
                        careerId = c.Int(nullable: false, identity: true),
                        career = c.String(),
                    })
                .PrimaryKey(t => t.careerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CAREERS");
        }
    }
}
