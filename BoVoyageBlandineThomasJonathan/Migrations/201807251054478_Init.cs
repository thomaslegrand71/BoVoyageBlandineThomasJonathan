namespace BoVoyageBlandineThomasJonathan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Destinations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Continent = c.String(maxLength: 50),
                        Pays = c.String(maxLength: 50),
                        Region = c.String(maxLength: 50),
                        Description = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Destinations");
        }
    }
}
